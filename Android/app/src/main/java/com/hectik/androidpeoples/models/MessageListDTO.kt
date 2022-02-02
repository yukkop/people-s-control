package com.hectik.androidpeoples.models

import kotlinx.serialization.Serializable

@Serializable
data class MessageListDTO<Entity>(
    val status: Int,
    val statusString: String,
    val message: String,
    val entity: List<Entity>
)

fun <Entity> MessageListDTO<Entity>.statusCheckRun(statusOk: () -> Unit, statusNoOk: () -> Unit)
{
    if (status == 0)
    {
        statusOk()
    } else
    {
        statusNoOk()
    }
}


