package com.hectik.androidpeoples.viewModels

import androidx.lifecycle.ViewModel
import com.hectik.androidpeoples.models.DistrictDTO
import com.hectik.androidpeoples.models.RegionDTO

class UserViewModel : ViewModel()
{
    lateinit var region: RegionDTO
    lateinit var district: DistrictDTO
    lateinit var name: String
    lateinit var surname: String
    lateinit var patronymic: String
    lateinit var email: String
    lateinit var phone: String
    var notifyByEmail: Boolean = false
    var notifyBySMS: Boolean = false
    var emailConfirm: Boolean = false
    var phoneConfirm: Boolean = false
    var authorized = false

    val isDistrictInitialized get() = this::district.isInitialized
    val isRegionInitialized get() = this::region.isInitialized
    val isNameInitialized get() = this::name.isInitialized
    val isSurnameInitialized get() = this::surname.isInitialized
    val isPatronimicInitialized get() = this::patronymic.isInitialized
    val isEmailInitialized get() = this::email.isInitialized

}