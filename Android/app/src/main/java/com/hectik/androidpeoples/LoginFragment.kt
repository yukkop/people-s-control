package com.hectik.androidpeoples

import android.os.Bundle
import android.text.InputType
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.fragment.app.activityViewModels
import androidx.navigation.findNavController
import com.google.android.material.button.MaterialButton
import com.hectik.androidpeoples.models.statusCheckRun
import com.hectik.androidpeoples.services.AuthService
import com.hectik.androidpeoples.viewModels.UserViewModel
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch

/**
 * A simple [Fragment] subclass.
 * Use the [LoginFragment.newInstance] factory method to
 * create an instance of this fragment.
 */
class LoginFragment : Fragment()
{
    private var loginToggle = LoginType.E_MAIL
    private val authorizationService = AuthService()
    private lateinit var loginToggleEmailView: TextView
    private lateinit var loginTogglePhoneView: TextView
    private lateinit var registrationButtonView: TextView
    private lateinit var loginInputView: EditText
    private lateinit var passwordInputView: EditText
    private lateinit var loginButtonEnter: MaterialButton
    private lateinit var skipButtonView: TextView
    private val userModel: UserViewModel by activityViewModels()


    override fun onCreate(savedInstanceState: Bundle?)
    {
        super.onCreate(savedInstanceState)
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View?
    {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_login, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?)
    {
        super.onViewCreated(view, savedInstanceState)
        findAllView(view)
        setListeners()
    }

    private fun findAllView(viewFragment: View)
    {
        loginToggleEmailView = viewFragment.findViewById(R.id.emailToggleButtonOnLoginPage)
        loginTogglePhoneView = viewFragment.findViewById(R.id.phoneToggleButtonOnLoginPage)
        loginInputView = viewFragment.findViewById(R.id.inputLoginOnLoginPage)
        passwordInputView = viewFragment.findViewById(R.id.inputPassOnLoginPage)
        loginButtonEnter = viewFragment.findViewById(R.id.loginButtonEnter)
        registrationButtonView = viewFragment.findViewById(R.id.LoginPageRegistrationTextButton)
        skipButtonView = viewFragment.findViewById(R.id.skipButtonOnLoginPage)
    }

    private fun setListeners()
    {
        skipButtonView.setOnClickListener {
            it.findNavController().navigate(R.id.action_loginFragment_to_mainMenuFragment)
        }

        loginToggleEmailView.setOnClickListener {
            loginToggle = LoginType.E_MAIL
            toggleStyleSet()
        }
        loginTogglePhoneView.setOnClickListener {
            loginToggle = LoginType.PHONE
            toggleStyleSet()
        }


        registrationButtonView.setOnClickListener {
            it.findNavController().navigate(R.id.action_loginFragment_to_registration)
        }

        loginButtonEnter.setOnClickListener {
            when (loginToggle)
            {
                LoginType.E_MAIL ->
                {
                    userModel.email = loginInputView.text.toString()
                    GlobalScope.launch(Dispatchers.Main)
                    {
                        val authMessage = authorizationService.authorization(
                            userModel.email,
                            passwordInputView.text.toString()
                        )
                        authMessage.statusCheckRun(
                            statusOk = {
                                userModel.authorized = true
                                userModel.email = authMessage.entity?.emailAddress ?: ""
                                userModel.name = authMessage.entity?.name ?: ""
                                userModel.surname = authMessage.entity?.surname ?: ""
                                userModel.patronymic = authMessage.entity?.patronymic ?: ""
                                userModel.phone = authMessage.entity?.phoneNumber ?: ""
                                userModel.district.id = authMessage.entity?.districtId ?: 0
                                userModel.district.name = authMessage.entity?.districtName ?: ""
                                userModel.district.cityName = authMessage.entity?.cityName ?: ""
                                userModel.notifyByEmail = authMessage.entity?.notifyByEmail ?: false
                                userModel.notifyBySMS = authMessage.entity?.notifyBySMS ?: false
                                it.findNavController()
                                    .navigate(R.id.action_loginFragment_to_mainMenuFragment)
                            },
                            statusNoOk = {
                                userModel.authorized = false
                                Toast.makeText(context, "Неверный логин/пароль", Toast.LENGTH_LONG)
                                    .show()
                            }
                        )
                    }
                }
                LoginType.PHONE ->
                {
                    userModel.phone = loginInputView.text.toString()
                    GlobalScope.launch(Dispatchers.Main)
                    {
                        val authMessage = authorizationService.authorization(
                            userModel.phone,
                            passwordInputView.text.toString()
                        )
                        authMessage.statusCheckRun(
                            statusOk = {
                                userModel.district.id = authMessage.entity?.districtId ?: 0
                                userModel.district.name = authMessage.entity?.districtName ?: ""
                                userModel.district.cityName = authMessage.entity?.cityName ?: ""
                                userModel.email = authMessage.entity?.emailAddress ?: ""
                                userModel.phone = authMessage.entity?.phoneNumber ?: ""
                                userModel.name = authMessage.entity?.name?: ""
                                userModel.surname = authMessage.entity?.surname ?: ""
                                userModel.patronymic = authMessage.entity?.patronymic ?: ""
                                userModel.authorized = true
                                it.findNavController().navigate(R.id.action_loginFragment_to_mainMenuFragment)
                            },
                            statusNoOk = {
                                userModel.authorized = false
                                Toast.makeText(context, "Неверный логин/пароль", Toast.LENGTH_LONG)
                                    .show()
                            }
                        )
                    }
                }
            }
        }
    }

    private fun toggleStyleSet()
    {
        if (loginToggle == LoginType.E_MAIL)
        {
            loginToggleEmailView.setTextAppearance(R.style.TextAppearance_AppCompat_TogleText_Active)
            loginTogglePhoneView.setTextAppearance(R.style.TextAppearance_AppCompat_TogleText_Inactive)
            loginInputView.setHint(R.string.input_email_hint)
            loginInputView.inputType = InputType.TYPE_TEXT_VARIATION_EMAIL_ADDRESS
            loginInputView.text.clear()
        } else
        {
            loginToggleEmailView.setTextAppearance(R.style.TextAppearance_AppCompat_TogleText_Inactive)
            loginTogglePhoneView.setTextAppearance(R.style.TextAppearance_AppCompat_TogleText_Active)
            loginInputView.setHint(R.string.input_phone_hint)
            loginInputView.inputType = InputType.TYPE_CLASS_PHONE
            loginInputView.text.clear()
        }
    }
}