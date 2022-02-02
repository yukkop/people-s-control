package com.hectik.androidpeoples.viewModels

import androidx.lifecycle.ViewModel
import com.hectik.androidpeoples.models.CoordinatesDTO

class ReportViewModel : ViewModel()
{
    lateinit var title: String
    var relationReportId: Long = 0
    lateinit var coordinatesDTO: CoordinatesDTO
    lateinit var address: String
    var statusId: Long = 0
    var isRequestModeration = true
    var isAnonymously = true
}