package com.hectik.androidpeoples

import android.os.Bundle
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

class ConfirmFragment : Fragment()
{
    private val registrationService = AuthService()
    private lateinit var codeInputView: EditText
    private lateinit var confirmButton: MaterialButton
    private lateinit var resendButton: TextView
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
        return inflater.inflate(R.layout.fragment_confirm, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?)
    {
        super.onViewCreated(view, savedInstanceState)
        codeInputView = view.findViewById(R.id.inputCodeOnConfirmPage)
        confirmButton = view.findViewById(R.id.confirmButtonOnConfirmPage)
        resendButton = view.findViewById(R.id.resendButtonOnConfirmPage)
        confirmButton.setOnClickListener {
            GlobalScope.launch(Dispatchers.IO) {
                val confirmMessage =
                    registrationService.putConfirmCode(codeInputView.text.toString().toInt())
                confirmMessage.statusCheckRun(
                    statusOk = {
                        userModel.emailConfirm = true
                        it.findNavController()
                            .navigate(R.id.action_confirmFragment_to_mainMenuFragment)
                    },
                    statusNoOk =
                    {
                        Toast.makeText(context, "Неверный код подтверждения", Toast.LENGTH_LONG)
                            .show()
                    }
                )
            }
        }
        resendButton.setOnClickListener {
            GlobalScope.launch(Dispatchers.IO) {
                registrationService.resendConfirmCode()
            }
        }
    }

}