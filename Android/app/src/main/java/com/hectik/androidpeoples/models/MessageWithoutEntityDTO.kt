package com.hectik.androidpeoples.models

import kotlinx.serialization.Serializable

@Serializable
data class MessageWithoutEntityDTO(
    val status: Int,
    val statusString: String,
    val message: String
)

fun MessageWithoutEntityDTO.statusCheckRun(statusOk: () -> Unit, statusNoOk: () -> Unit)
{
    if (status == 0)
    {
        statusOk()
    } else
    {
        statusNoOk()
    }
}