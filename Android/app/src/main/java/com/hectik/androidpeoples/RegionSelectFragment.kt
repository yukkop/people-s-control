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
import java.util.*

class RegionSelectFragment : Fragment()
{
    private val registrationService = AuthService()
    private lateinit var regionListView: LinearLayout
    private lateinit var soonListView: LinearLayout
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
        return inflater.inflate(R.layout.fragment_region_select, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?): Unit = runBlocking {

        super.onViewCreated(view, savedInstanceState)
        regionListView = view.findViewById(R.id.region_list)
        soonListView = view.findViewById(R.id.soon_list)

        view.findViewById<MaterialButton>(R.id.cancelButtonRegionSelectPage).setOnClickListener {
            it.findNavController().navigate(R.id.action_regionSelectFragment_to_loginFragment)
        }

        var supportRegionList = withContext(Dispatchers.Default) {
                registrationService.getSupportedRegion()
            }

        supportRegionList.statusCheckRun(
            statusOk = {
                for (curRegion in supportRegionList.entity)
                {
                    var regionView = TextView(view.context)
                    regionView.text = curRegion.cityName
                    var param = ViewGroup.MarginLayoutParams(
                        ViewGroup.LayoutParams.WRAP_CONTENT,
                        ViewGroup.LayoutParams.WRAP_CONTENT
                    )
                    param.topMargin = 15
                    param.bottomMargin = 15
                    regionView.layoutParams = param
                    regionView.setTextAppearance(R.style.TextAppearance_AppCompat_RegionList)
                    regionView.typeface = Typeface.DEFAULT
                    regionView.setOnClickListener {
                        for (currView in regionListView.children)
                        {
                            (currView as TextView).typeface = Typeface.DEFAULT
                        }
                        regionView.typeface = Typeface.DEFAULT_BOLD
                        userModel.region = curRegion
                    }
                    regionListView.addView(regionView)
                }
            },
            statusNoOk =
            {
                Toast.makeText(context, supportRegionList.message, Toast.LENGTH_LONG)
                    .show()
            }
        )

        var unsupportRegionList = withContext(Dispatchers.Default) {
                registrationService.getUnsupportedRegion()
            }
        unsupportRegionList.statusCheckRun(
            statusOk = {
                for (curRegion in unsupportRegionList.entity)
                {
                    val regionView = TextView(view.context)
                    regionView.text = curRegion.cityName
                    val param = ViewGroup.MarginLayoutParams(
                        ViewGroup.LayoutParams.WRAP_CONTENT,
                        ViewGroup.LayoutParams.WRAP_CONTENT
                    )
                    param.topMargin = 5
                    param.bottomMargin = 5
                    regionView.layoutParams = param
                    regionView.setTextAppearance(R.style.TextAppearance_AppCompat_TogleText)
                    soonListView.addView(regionView)
                }
            },
            statusNoOk = {
                Toast.makeText(context, supportRegionList.message, Toast.LENGTH_LONG)
                    .show()
            }
        )

        view.findViewById<MaterialButton>(R.id.selectButtonRegionSelectPage).setOnClickListener {
            if (userModel.isRegionInitialized)
            {
                it.findNavController().navigate(R.id.action_regionSelectFragment_to_districtSelectFragment)
            } else
            {
                Toast.makeText(context, "Выберите регион", Toast.LENGTH_LONG)
                    .show()
            }
        }
    }

}