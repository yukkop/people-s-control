package com.hectik.androidpeoples

object Config
{
    const val BASE_URL = "https://10.0.2.2:44373/api"
    const val HOST = "localhost:44373"
    const val SUPPORTED_REGION_URL = "$BASE_URL/Region/Supported"
    const val UNSUPPORTED_REGION_URL = "$BASE_URL/Region/Unsupported"
    const val DISTRICT_BY_CITY = "$BASE_URL/District/ByCity/"
    const val REGISTRATION_EMAIL = "$BASE_URL/user/registration/Email"
    const val CONFIRM_EMAIL = "$BASE_URL/user/registration/Email/"
    const val RESEND_CONFIRM_CODE = "$BASE_URL/user/registration/Email/resend"
    const val AUTHORIZATION = "$BASE_URL/user/Authorization"
}