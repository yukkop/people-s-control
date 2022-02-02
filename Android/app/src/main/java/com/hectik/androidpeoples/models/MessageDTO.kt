package com.hectik.androidpeoples.models

import kotlinx.serialization.Serializable

@Serializable
data class MessageDTO<Entity>(
    val status: Int,
    val statusString: String,
    val message: String,
    val entity: Entity?
)

fun <Entity> MessageDTO<Entity>.statusCheckRun(statusOk: () -> Unit, statusNoOk: () -> Unit)
{
    if (status == 0)
    {
        statusOk()
    } else
    {
        statusNoOk()
    }
}
