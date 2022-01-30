package com.hectik.androidpeoples

import android.os.Bundle
import android.text.InputType
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.EditText
import android.widget.TextView
import androidx.fragment.app.Fragment
import androidx.navigation.findNavController
import com.google.android.material.button.MaterialButton
import org.w3c.dom.Text

/**
 * A simple [Fragment] subclass.
 * Use the [LoginFragment.newInstance] factory method to
 * create an instance of this fragment.
 */
class LoginFragment : Fragment()
{
    private var loginToggle = LoginType.E_MAIL
    private lateinit var loginToggleEmailView: TextView
    private lateinit var loginTogglePhoneView: TextView
    private lateinit var loginInputView: EditText
    private lateinit var loginButtonEnter: MaterialButton

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
        loginToggleEmailView = view.findViewById(R.id.emailToggleButtonOnLoginPage)
        loginTogglePhoneView = view.findViewById(R.id.phoneToggleButtonOnLoginPage)
        loginInputView = view.findViewById(R.id.inputLoginOnLoginPage)
        loginButtonEnter = view.findViewById(R.id.loginButtonEnter)
        loginToggleEmailView.setOnClickListener {
            loginToggle = LoginType.E_MAIL
            toggleStyleSet()
        }
        loginTogglePhoneView.setOnClickListener {
            loginToggle = LoginType.PHONE
            toggleStyleSet()
        }
        view.findViewById<TextView>(R.id.LoginPageRegistrationTextButton).setOnClickListener {
            it.findNavController().navigate(R.id.action_loginFragment_to_registration)
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