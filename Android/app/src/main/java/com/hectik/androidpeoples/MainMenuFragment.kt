package com.hectik.androidpeoples

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.constraintlayout.widget.ConstraintLayout
import androidx.constraintlayout.widget.ConstraintSet
import androidx.fragment.app.Fragment
import androidx.fragment.app.activityViewModels
import androidx.navigation.findNavController
import androidx.navigation.fragment.findNavController
import com.google.android.material.button.MaterialButton
import com.hectik.androidpeoples.viewModels.UserViewModel

class MainMenuFragment : Fragment()
{
    private lateinit var constraintLayout: ConstraintLayout
    private lateinit var applicationButton: MaterialButton

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
        return inflater.inflate(R.layout.fragment_main_menu, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?)
    {
        super.onViewCreated(view, savedInstanceState)
        findAllView(view)
        setListeners()
        if (!userModel.authorized)
        {
            createLoginButton(view)
        }
    }

    fun findAllView(view: View)
    {
        constraintLayout = view.findViewById(R.id.constraint_main_menu)
    }

    fun setListeners()
    {
        applicationButton.setOnClickListener {
            findNavController().navigate(R.id.action_mainMenuFragment_to_applicationMenuFragment)
        }
    }
    
    fun createLoginButton(view: View)
    {
        val loginButton = TextView(view.context)
        loginButton.id = R.id.login_view_on_main_menu_page
        loginButton.text = getString(R.string.main_menu_login_str)
        val param = ViewGroup.MarginLayoutParams(
            ViewGroup.LayoutParams.WRAP_CONTENT,
            ViewGroup.LayoutParams.WRAP_CONTENT
        )
        loginButton.layoutParams = param
        loginButton.setTextAppearance(R.style.TextAppearance_AppCompat_PrimaryLink)
        loginButton.setOnClickListener {
            findNavController().navigate(R.id.action_mainMenuFragment_to_loginFragment)
        }
        constraintLayout.addView(loginButton)
        val set = ConstraintSet()
        set.clone(constraintLayout)
        set.connect(R.id.login_view_on_main_menu_page, ConstraintSet.START, R.id.constraint_main_menu, ConstraintSet.START)
        set.connect(R.id.login_view_on_main_menu_page, ConstraintSet.END, R.id.constraint_main_menu, ConstraintSet.END)
        set.connect(R.id.login_view_on_main_menu_page, ConstraintSet.BOTTOM, R.id.textView7, ConstraintSet.TOP)
        set.connect(R.id.login_view_on_main_menu_page, ConstraintSet.TOP, R.id.linearLayout2, ConstraintSet.BOTTOM)
        set.applyTo(constraintLayout)
    }

}