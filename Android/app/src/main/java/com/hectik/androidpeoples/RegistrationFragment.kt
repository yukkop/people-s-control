package com.hectik.androidpeoples

import android.os.Bundle
import android.text.InputType
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.EditText
import android.widget.TextView
import androidx.fragment.app.Fragment
import androidx.fragment.app.activityViewModels
import com.hectik.androidpeoples.viewModels.UserViewModel


class RegistrationFragment : Fragment()
{

    private var loginToggle = LoginType.E_MAIL
    private lateinit var loginToggleEmailView: TextView
    private lateinit var loginTogglePhoneView: TextView
    private lateinit var loginInputView: EditText
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
        loginToggleEmailView = view.findViewById(R.id.emailToggleButtonOnRegistrationPage)
        loginTogglePhoneView = view.findViewById(R.id.phoneToggleButtonOnRegistrationPage)
        loginInputView = view.findViewById(R.id.inputLoginOnRegistrationPage)
        loginToggleEmailView.setOnClickListener {
            loginToggle = LoginType.E_MAIL
            toggleStyleSet()
        }
        loginTogglePhoneView.setOnClickListener {
            loginToggle = LoginType.PHONE
            toggleStyleSet()
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