package com.hectik.androidpeoples.models

import kotlinx.serialization.Serializable

@Serializable
data class UserRegistrationDTO(
    val emailAddress: String,
    val password: String,
    val name: String,
    val surname: String,
    val districtId: Long,
    val patronymic: String
)
{
    constructor(
        emailAddress: String,
        password: String,
        name: String,
        surname: String,
        districtId: Long
    ) : this(emailAddress, password, name, surname, districtId, "")
}
