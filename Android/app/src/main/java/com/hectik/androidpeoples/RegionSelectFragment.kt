package com.hectik.androidpeoples

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.LinearLayout
import androidx.fragment.app.Fragment
import com.hectik.androidpeoples.services.RegionService
import io.ktor.client.*
import io.ktor.client.features.*
import io.ktor.client.request.*
import io.ktor.client.statement.*
import io.ktor.http.*
import kotlinx.coroutines.*
import java.util.*

/**
 * A simple [Fragment] subclass.
 * Use the [RegionSelectFragment.newInstance] factory method to
 * create an instance of this fragment.
 */
class RegionSelectFragment : Fragment()
{
    val client = HttpClient()
    val regionService = RegionService()

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
        GlobalScope.launch(Dispatchers.IO) {
            val region_list = async {
                regionService.getSupportedRegion()
            }
        }
    }

}