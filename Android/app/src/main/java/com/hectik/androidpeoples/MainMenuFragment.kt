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
import com.hectik.androidpeoples.databinding.FragmentApplicationMenuBinding
import com.hectik.androidpeoples.databinding.FragmentMainMenuBinding
import com.hectik.androidpeoples.viewModels.UserViewModel

class MainMenuFragment : Fragment()
{
    private lateinit var binding: FragmentMainMenuBinding

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
        inflater.inflate(R.layout.fragment_main_menu, container, false)
        binding = FragmentMainMenuBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?)
    {
        super.onViewCreated(view, savedInstanceState)
        setListeners()
    }

    private fun setListeners()
    {
        binding.mainMenuButtonReq.setOnClickListener {
            findNavController().navigate(R.id.action_mainMenuFragment_to_applicationMenuFragment)
        }
        binding.mainMenuButtonProfile.setOnClickListener {
            userProfileAction()
        }
        binding.toolbar.profileButton.setOnClickListener {
            userProfileAction()
        }

    }

    private fun userProfileAction()
    {
        if (userModel.authorized)
        {

        } else
        {
            findNavController().navigate(R.id.action_mainMenuFragment_to_loginFragment)
        }
    }

}