package com.hectik.androidpeoples.models

import kotlinx.serialization.Serializable

@Serializable
data class CityDTO(
    val id: Long,
    val name: String
)
