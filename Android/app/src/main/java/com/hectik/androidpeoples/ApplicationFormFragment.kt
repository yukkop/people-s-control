package com.hectik.androidpeoples

import android.Manifest
import android.app.Activity
import android.app.Activity.RESULT_CANCELED
import android.app.Activity.RESULT_OK
import android.content.ContentResolver
import android.content.Intent
import android.content.pm.PackageManager
import android.content.res.Resources
import android.database.Cursor
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.CheckBox
import android.widget.ImageView
import android.widget.TextView
import androidx.constraintlayout.widget.ConstraintSet
import androidx.core.content.ContextCompat.checkSelfPermission
import androidx.core.view.children
import androidx.fragment.app.Fragment
import androidx.fragment.app.activityViewModels
import com.hectik.androidpeoples.databinding.FragmentApplicationFormBinding
import com.hectik.androidpeoples.databinding.FragmentApplicationMenuBinding
import com.hectik.androidpeoples.viewModels.UserViewModel
import kotlinx.android.synthetic.main.fragment_application_form.view.*
import android.graphics.BitmapFactory

import android.graphics.Bitmap
import android.graphics.Matrix
import android.net.Uri
import android.os.Build
import android.provider.MediaStore
import com.squareup.picasso.Picasso
import android.os.ParcelFileDescriptor
import android.view.RoundedCorner
import com.bumptech.glide.Glide
import java.io.FileDescriptor
import com.bumptech.glide.request.RequestOptions
import com.bumptech.glide.load.resource.bitmap.RoundedCorners

import com.bumptech.glide.load.resource.bitmap.CenterCrop
import android.widget.ImageView.ScaleType
import androidx.annotation.RequiresApi


class ApplicationFormFragment : Fragment()
{
    private lateinit var binding: FragmentApplicationFormBinding
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
        inflater.inflate(R.layout.fragment_application_form, container, false)
        binding = FragmentApplicationFormBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?)
    {
        super.onViewCreated(view, savedInstanceState)
        if (userModel.authorized)
        {
            addConnectProfileCheckbox()
        } else
        {
            addEnterInAccountText()
        }
        binding.addContent.setOnClickListener {
            if (checkSelfPermission(
                    view.context,
                    Manifest.permission.READ_EXTERNAL_STORAGE
                ) == PackageManager.PERMISSION_DENIED
            )
            {
                val permissions = arrayOf(Manifest.permission.READ_EXTERNAL_STORAGE)
                requestPermissions(permissions, PERMISSION_CODE)
            } else
            {
                chooseImageGallery();
            }
        }
    }

    private fun addConnectProfileCheckbox()
    {
        val connectDataProfileCheckBox = CheckBox(context)
        val param =
            context?.resources?.getDimensionPixelOffset(R.dimen.text_dimen_application_form_page)
                ?.let {
                    ViewGroup.LayoutParams(
                        it,
                        ViewGroup.LayoutParams.WRAP_CONTENT
                    )
                }
        connectDataProfileCheckBox.layoutParams = param
        connectDataProfileCheckBox.text = R.string.connect_data_application_form_page.toString()
        connectDataProfileCheckBox.id = R.id.connect_data_profile
        val set = ConstraintSet()
        binding.constraint.addView(connectDataProfileCheckBox)
        set.clone(binding.constraint)
        set.connect(
            connectDataProfileCheckBox.id,
            ConstraintSet.BOTTOM,
            binding.constraint.rules_check_box.id,
            ConstraintSet.TOP
        )
        set.connect(
            connectDataProfileCheckBox.id,
            ConstraintSet.START,
            binding.constraint.rules_check_box.id,
            ConstraintSet.START
        )
        set.connect(
            connectDataProfileCheckBox.id,
            ConstraintSet.END,
            binding.constraint.rules_check_box.id,
            ConstraintSet.END
        )
        set.applyTo(binding.constraint)
    }

    private fun addEnterInAccountText()
    {
        val enterInAccount = TextView(context)
        val param =
            context?.resources?.getDimensionPixelOffset(R.dimen.text_dimen_application_form_page)
                ?.let {
                    ViewGroup.LayoutParams(
                        it,
                        ViewGroup.LayoutParams.WRAP_CONTENT
                    )
                }
        enterInAccount.layoutParams = param
        enterInAccount.text = getString(R.string.enter_in_account_form_page)
        enterInAccount.id = R.id.enter_in_account_application_form_page
        val set = ConstraintSet()
        binding.constraint.addView(enterInAccount)
        set.clone(binding.constraint)
        set.connect(
            enterInAccount.id,
            ConstraintSet.BOTTOM,
            binding.constraint.rules_check_box.id,
            ConstraintSet.TOP
        )
        set.connect(
            enterInAccount.id,
            ConstraintSet.START,
            binding.constraint.rules_check_box.id,
            ConstraintSet.START
        )
        set.connect(
            enterInAccount.id,
            ConstraintSet.END,
            binding.constraint.rules_check_box.id,
            ConstraintSet.END
        )
        set.applyTo(binding.constraint)
    }

    private fun chooseImageGallery()
    {
        val intent = Intent(
            Intent.ACTION_PICK,
            android.provider.MediaStore.Images.Media.EXTERNAL_CONTENT_URI
        )
        intent.type = "image/*"
        startActivityForResult(intent, 1)
    }

    @RequiresApi(Build.VERSION_CODES.Q)
    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?)
    {
        if (resultCode != RESULT_CANCELED)
        {
            var viewImage = ImageView(context)
            val param =
                context?.resources?.getDimensionPixelOffset(R.dimen.photo_dimen_application_form_page)
                    ?.let {
                        ViewGroup.LayoutParams(
                            it,
                            it
                        )
                    }
            viewImage.layoutParams = param
            var requestOptions = RequestOptions().transform(RoundedCorners(16))
            when (requestCode)
            {
                0 -> if (resultCode === RESULT_OK && data != null)
                {
                    val selectedImage = data.extras!!["data"] as Bitmap?
                    context?.let {
                        Glide.with(it).load(selectedImage).apply(requestOptions).into(viewImage)
                    }
                }
                1 -> if (resultCode === RESULT_OK && data != null)
                {
                    val selectedImage = data.data
                    val filePathColumn = arrayOf(MediaStore.Images.Media.DATA)
                    if (selectedImage != null)
                    {
                        val cursor: Cursor? = context?.contentResolver?.query(
                            selectedImage,
                            filePathColumn,
                            null,
                            null,
                            null
                        )
                        if (cursor != null)
                        {
                            cursor.moveToFirst()
                            val columnIndex = cursor.getColumnIndex(filePathColumn[0])
                            val picturePath = cursor.getString(columnIndex)
                            context?.let {
                                Glide.with(it).load(selectedImage).apply(requestOptions)
                                    .into(viewImage)
                            }
                            cursor.close()
                        }
                    }
                }
            }
            viewImage.setOnClickListener {
                binding.contentList.removeView(viewImage)
            }
            binding.contentList.addView(viewImage)
        }
    }


    companion object
    {
        private const val IMAGE_CHOOSE = 100;
        private const val PERMISSION_CODE = 1001;
    }
}