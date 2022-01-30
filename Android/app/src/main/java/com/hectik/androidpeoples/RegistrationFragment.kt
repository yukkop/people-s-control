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
import kotlinx.coroutines.*


class RegistrationFragment : Fragment()
{
    private val registrationService = AuthService()
    private var loginToggle = LoginType.E_MAIL
    private lateinit var loginToggleEmailView: TextView
    private lateinit var loginTogglePhoneView: TextView
    private lateinit var loginInputView: EditText
    private lateinit var passwordInputView: EditText
    private lateinit var nameInputView: EditText
    private lateinit var surnameInputView: EditText
    private lateinit var patronimicInputView: EditText
    private lateinit var continueButton: MaterialButton
    private lateinit var cancelButton: MaterialButton
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
        return inflater.inflate(R.layout.fragment_registration, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?)
    {
        super.onViewCreated(view, savedInstanceState)
        findAllView(view)
        setListeners()
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

    private fun findAllView(viewFragment: View)
    {
        loginToggleEmailView = viewFragment.findViewById(R.id.emailToggleButtonOnRegistrationPage)
        loginTogglePhoneView = viewFragment.findViewById(R.id.phoneToggleButtonOnRegistrationPage)
        loginInputView = viewFragment.findViewById(R.id.inputLoginOnRegistrationPage)
        passwordInputView = viewFragment.findViewById(R.id.inputPassOnRegistrationPage)
        nameInputView = viewFragment.findViewById(R.id.inputNameOnRegistrationPage)
        surnameInputView = viewFragment.findViewById(R.id.inputSurnameOnRegistrationPage)
        patronimicInputView = viewFragment.findViewById(R.id.inputPatronimicOnRegistrationPage)
        continueButton = viewFragment.findViewById(R.id.continueButtonRegistrationPage)
        cancelButton = viewFragment.findViewById(R.id.cancelButtonRegistrationPage)
    }

    @DelicateCoroutinesApi
    private fun setListeners()
    {
        continueButton.setOnClickListener {
            when
            {
                loginInputView.text.toString() == "" ->
                {
                    Toast.makeText(context, "Введите логин", Toast.LENGTH_SHORT)
                        .show()
                }
                passwordInputView.text.toString() == "" ->
                {
                    Toast.makeText(context, "Введите пароль", Toast.LENGTH_SHORT)
                        .show()
                }
                nameInputView.text.toString() == "" ->
                {
                    Toast.makeText(context, "Введите имя", Toast.LENGTH_SHORT)
                        .show()
                }
                surnameInputView.text.toString() == "" ->
                {
                    Toast.makeText(context, "Введите фамилию", Toast.LENGTH_SHORT)
                        .show()
                }
                else ->
                {
                    userModel.email = loginInputView.text.toString()
                    userModel.name = nameInputView.text.toString()
                    userModel.password = passwordInputView.text.toString()
                    userModel.name = nameInputView.text.toString()
                    userModel.surname = surnameInputView.text.toString()
                    userModel.patronimic = patronimicInputView.text.toString()
                    GlobalScope.launch(Dispatchers.IO) {
                        val registrationMessage =
                            withContext(Dispatchers.IO) {
                                registrationService.postUserRegistration(
                                    userModel.email,
                                    userModel.password,
                                    userModel.name,
                                    userModel.surname,
                                    userModel.district.id,
                                    userModel.patronimic
                                )
                            }
                        registrationMessage.statusCheckRun(
                            statusOk =
                            {
                                it.findNavController().navigate(R.id.action_registration_to_confirmFragment)
                            },
                            statusNoOk =
                            {
                                Toast.makeText(context, "Недействительный e-mail", Toast.LENGTH_LONG)
                                    .show()
                            }
                        )
                    }

                }
            }
        }

        loginToggleEmailView.setOnClickListener {
            loginToggle = LoginType.E_MAIL
            toggleStyleSet()
        }
        loginTogglePhoneView.setOnClickListener {
            loginToggle = LoginType.PHONE
            toggleStyleSet()
        }

        cancelButton.setOnClickListener {
            it.findNavController().navigate(R.id.action_registration_to_loginFragment)
        }
    }
}