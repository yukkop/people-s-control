package com.hectik.androidpeoples.models

import kotlinx.serialization.Serializable

@Serializable
data class UserDTO(
    var name: String,
    var surname: String,
    var patronymic: String,
    var phoneNumber: String?,
    var emailAddress: String,
    var districtId: Long,
    var districtName: String,
    var cityId: Long,
    var cityName: String,
    var notifyByEmail: Boolean,
    var notifyBySMS: Boolean,
    var avatar: String
)