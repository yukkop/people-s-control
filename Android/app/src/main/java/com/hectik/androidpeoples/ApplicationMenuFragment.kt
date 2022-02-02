package com.hectik.androidpeoples

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import androidx.navigation.fragment.findNavController
import com.hectik.androidpeoples.databinding.FragmentApplicationMenuBinding

// TODO: Rename parameter arguments, choose names that match
// the fragment initialization parameters, e.g. ARG_ITEM_NUMBER

/**
 * A simple [Fragment] subclass.
 * Use the [ApplicationMenuFragment.newInstance] factory method to
 * create an instance of this fragment.
 */
class ApplicationMenuFragment : Fragment()
{
    private lateinit var binding: FragmentApplicationMenuBinding
    override fun onCreate(savedInstanceState: Bundle?)
    {
        super.onCreate(savedInstanceState)
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View
    {
        inflater.inflate(R.layout.fragment_application_menu, container, false)
        binding = FragmentApplicationMenuBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?)
    {
        super.onViewCreated(view, savedInstanceState)
        binding.buttonCreate.setOnClickListener {
            findNavController().navigate(R.id.action_applicationMenuFragment_to_applicationFormFragment)
        }

    }
}