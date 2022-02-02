package com.hectik.androidpeoples.services

import com.hectik.androidpeoples.Config
import io.ktor.client.*
import com.hectik.androidpeoples.models.*
import io.ktor.client.engine.cio.*
import io.ktor.client.features.json.*
import io.ktor.client.features.json.serializer.*
import io.ktor.client.request.*
import io.ktor.http.*
import kotlinx.serialization.json.buildJsonObject
import kotlinx.serialization.json.put
import java.security.cert.X509Certificate
import java.util.*
import javax.net.ssl.X509TrustManager

class AuthService
{
    private val client = HttpClient(CIO) {
        install(JsonFeature) {
            serializer = KotlinxSerializer()
        }
        engine {
            https {
                trustManager = object : X509TrustManager
                {
                    override fun checkClientTrusted(
                        p0: Array<out X509Certificate>?,
                        p1: String?
                    )
                    {
                    }

                    override fun checkServerTrusted(
                        p0: Array<out X509Certificate>?,
                        p1: String?
                    )
                    {
                    }

                    override fun getAcceptedIssuers(): Array<X509Certificate>? = null
                }
            }
        }
    }

    suspend fun getSupportedRegion(): MessageListDTO<RegionDTO>
    {
        return try
        {
            client.get(Config.SUPPORTED_REGION_URL)
            {
                headers {
                    val auth = "Basic " + Base64.getEncoder().encodeToString("guest:".toByteArray())
                    append(HttpHeaders.Authorization, auth)
                    append(HttpHeaders.Host, Config.HOST)
                }
            }
        } catch (e: Exception)
        {
            MessageListDTO(1, "Error", "Error 404", emptyList())
        }
    }

    suspend fun getUnsupportedRegion(): MessageListDTO<RegionDTO>
    {
        return try
        {
            client.get(Config.UNSUPPORTED_REGION_URL)
            {
                headers {
                    val auth = "Basic " + Base64.getEncoder().encodeToString("guest:".toByteArray())
                    append(HttpHeaders.Authorization, auth)
                    append(HttpHeaders.Host, Config.HOST)
                }
            }
        } catch (e: Exception)
        {
            MessageListDTO(1, "Error", "Error 404", emptyList())
        }
    }

    suspend fun getDistrictsByCity(cityName: String): MessageListDTO<DistrictDTO>
    {
        return try
        {
            client.get(Config.DISTRICT_BY_CITY + cityName)
            {
                headers {
                    val auth = "Basic " + Base64.getEncoder().encodeToString("guest:".toByteArray())
                    append(HttpHeaders.Authorization, auth)
                    append(HttpHeaders.Host, Config.HOST)
                }
            }
        } catch (e: Exception)
        {
            MessageListDTO(1, "Error", "Error 404", emptyList())
        }
    }

    suspend fun postUserRegistration(
        email: String,
        password: String,
        name: String, surname: String,
        districtId: Long,
        patronymic: String = ""
    ): MessageWithoutEntityDTO
    {
        return try
        {
            client.post(Config.REGISTRATION_EMAIL)
            {
                headers {
                    val auth = "Basic " + Base64.getEncoder().encodeToString("guest:".toByteArray())
                    append(HttpHeaders.Authorization, auth)
                    append(HttpHeaders.Host, Config.HOST)
                }
                contentType(ContentType.Application.Json)
                body = UserRegistrationDTO(email, password, name, surname, districtId, patronymic)
            }
        } catch (e: Exception)
        {
            MessageWithoutEntityDTO(1, "Error", "Error 404")
        }
    }

    suspend fun putConfirmCode(code: Int): MessageWithoutEntityDTO
    {
        return try
        {
            client.put("${Config.CONFIRM_EMAIL}/${code}")
            {
                headers {
                    val auth = "Basic " + Base64.getEncoder().encodeToString("guest:".toByteArray())
                    append(HttpHeaders.Authorization, auth)
                    append(HttpHeaders.Host, Config.HOST)
                }
            }
        } catch (e: Exception)
        {
            MessageWithoutEntityDTO(1, "Error", "Error 404")
        }
    }

    suspend fun resendConfirmCode(): MessageWithoutEntityDTO
    {
        return try
        {
            client.put(Config.RESEND_CONFIRM_CODE)
            {
                headers {
                    val auth = "Basic " + Base64.getEncoder().encodeToString("guest:".toByteArray())
                    append(HttpHeaders.Authorization, auth)
                    append(HttpHeaders.Host, Config.HOST)
                }
            }
        } catch (e: Exception)
        {
            MessageWithoutEntityDTO(1, "Error", "Error 404")
        }
    }

    suspend fun authorization(login: String, password: String): MessageDTO<UserDTO>
    {
        return try
        {
            client.get(Config.AUTHORIZATION)
            {
                headers {
                    val auth = "Basic " + Base64.getEncoder()
                        .encodeToString("${login}:${password}".toByteArray())
                    append(HttpHeaders.Authorization, auth)
                    append(HttpHeaders.Host, Config.HOST)
                }
            }
        } catch (e: Exception)
        {
            MessageDTO<UserDTO>(1, "Error", "Error 404", null)
        }
    }


}
