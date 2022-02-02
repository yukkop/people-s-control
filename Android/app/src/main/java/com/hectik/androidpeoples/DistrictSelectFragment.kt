package com.hectik.androidpeoples

import android.graphics.Typeface
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.LinearLayout
import android.widget.TextView
import android.widget.Toast
import androidx.core.view.children
import androidx.fragment.app.Fragment
import androidx.fragment.app.activityViewModels
import androidx.navigation.findNavController
import com.google.android.material.button.MaterialButton
import com.hectik.androidpeoples.models.statusCheckRun
import com.hectik.androidpeoples.services.AuthService
import com.hectik.androidpeoples.viewModels.UserViewModel
import kotlinx.coroutines.*


class DistrictSelectFragment : Fragment()
{
    private val registrationService = AuthService()
    private val userModel: UserViewModel by activityViewModels()

    override fun onCreate(savedInstanceState: Bundle?)
    {
        super.onCreate(savedInstanceState)
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View?
    {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_district_select, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?): Unit = runBlocking {
        super.onViewCreated(view, savedInstanceState)

        var districtListView = view.findViewById<LinearLayout>(R.id.district_list)
        view.findViewById<MaterialButton>(R.id.cancelButtonDistrictSelectPage).setOnClickListener {
            it.findNavController().navigate(R.id.action_districtSelectFragment_to_loginFragment)
        }
        val districtList = withContext(Dispatchers.IO) {
            registrationService.getDistrictsByCity(userModel.region.cityName)
        }
        districtList.statusCheckRun(
            statusOk =
            {
                for (curDistrict in districtList.entity)
                {
                    val districtView = TextView(view.context)
                    districtView.text = curDistrict.name
                    val param = ViewGroup.MarginLayoutParams(
                        ViewGroup.LayoutParams.WRAP_CONTENT,
                        ViewGroup.LayoutParams.WRAP_CONTENT
                    )
                    param.topMargin = 15
                    param.bottomMargin = 15
                    districtView.layoutParams = param
                    districtView.typeface = Typeface.DEFAULT
                    districtView.setTextAppearance(R.style.TextAppearance_AppCompat_RegionList)
                    districtView.setOnClickListener {
                        for (currView in districtListView.children)
                        {
                            (currView as TextView).typeface = Typeface.DEFAULT
                        }
                        districtView.typeface = Typeface.DEFAULT_BOLD
                        userModel.district = curDistrict
                    }
                    districtListView.addView(districtView)
                }
            },
            statusNoOk = {
                Toast.makeText(context, districtList.message, Toast.LENGTH_LONG)
                    .show()
            }
        )

        view.findViewById<MaterialButton>(R.id.selectButtonDistrictSelectPage).setOnClickListener {
            if (userModel.isDistrictInitialized)
            {
                it.findNavController().navigate(R.id.action_districtSelectFragment_to_registration)
            } else
            {
                Toast.makeText(context, "Выберите район", Toast.LENGTH_LONG)
                    .show()
            }
        }

    }
}