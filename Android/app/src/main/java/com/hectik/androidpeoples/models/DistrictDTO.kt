package com.hectik.androidpeoples.models

import kotlinx.serialization.Serializable

@Serializable
data class DistrictDTO(
    var id: Long,
    var name: String,
    var cityName: String
)
