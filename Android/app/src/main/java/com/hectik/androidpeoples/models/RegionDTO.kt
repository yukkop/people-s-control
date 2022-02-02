package com.hectik.androidpeoples.models

import kotlinx.serialization.Serializable

@Serializable
data class RegionDTO(
    val id: Long,
    val cityName: String
)

