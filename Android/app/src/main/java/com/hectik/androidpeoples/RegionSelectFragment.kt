package com.hectik.androidpeoples

import android.graphics.Typeface
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.LinearLayout
import android.widget.TextView
import androidx.core.view.children
import androidx.fragment.app.Fragment
import androidx.fragment.app.activityViewModels
import androidx.navigation.findNavController
import com.google.android.material.button.MaterialButton
import com.hectik.androidpeoples.services.RegistrationService
import com.hectik.androidpeoples.viewModels.UserViewModel
import kotlinx.coroutines.*
import java.util.*

/**
 * A simple [Fragment] subclass.
 * Use the [RegionSelectFragment.newInstance] factory method to
 * create an instance of this fragment.
 */
class RegionSelectFragment : Fragment()
{
    private val regionService = RegistrationService()
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
        var supportRegionList = async {
            regionService.getSupportedRegion()
        }
        for (curRegion in supportRegionList.await().entity)
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
            regionView.setOnClickListener {
                for (currView in regionListView.children)
                {
                    (currView as TextView).typeface = Typeface.DEFAULT
                }
                regionView.typeface = Typeface.DEFAULT_BOLD
                userModel.region = regionView.text as String
            }
            regionListView.addView(regionView)
        }

        var unsupportRegionList = async {
            regionService.getUnsupportedRegion()
        }
        for (curRegion in unsupportRegionList.await().entity)
        {
            var regionView = TextView(view.context)
            regionView.text = curRegion.cityName
            var param = ViewGroup.MarginLayoutParams(
                ViewGroup.LayoutParams.WRAP_CONTENT,
                ViewGroup.LayoutParams.WRAP_CONTENT
            )
            param.topMargin = 5
            param.bottomMargin = 5
            regionView.layoutParams = param
            regionView.setTextAppearance(R.style.TextAppearance_AppCompat_TogleText)
            soonListView.addView(regionView)
        }

        view.findViewById<MaterialButton>(R.id.selectButtonRegionSelectPage).setOnClickListener {
            it.findNavController().navigate(R.id.action_regionSelectFragment_to_districtSelectFragment, )
        }
    }

}