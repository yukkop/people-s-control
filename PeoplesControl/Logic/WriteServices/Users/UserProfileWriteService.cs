using AutoMapper;
using DataBase.Models;
using Logic.Helpers;
using Logic.Profiles;
using Logic.Repositories;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public class UserProfileWriteService : IUserProfileWriteService
    {
        IUserProfileRepository _userProfileRepository;
        IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserProfileWriteService(IUserProfileRepository userProfileRepository, IUserRepository userRepository, IMapper mapper)
        {
            _userProfileRepository = userProfileRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public ActionStatus<GetUserProfileDTO> Add(RegistrationDTO registrationEntity)
        {
            UserProfile userProfileEntity = _mapper.Map<UserProfile>(registrationEntity);

            userProfileEntity = _userProfileRepository.Add(userProfileEntity);
            _userProfileRepository.SaveChanges();
            /*
            User userEntity = _mapper.Map<User>(registrationEntity);
            
            userEntity.UserProfile = userProfileEntity;

            if (userProfileEntity.EmailAddress != null)
            {
                userEntity.EmailConfirmationCode = SendConfirmationEmail(userProfileEntity.EmailAddress);
            }
            else if (userProfileEntity.PhoneNumber != null)
            {
                userEntity.SMSConfirmationCode = SendConfirmationSMS(userProfileEntity.PhoneNumber);
            }
            userEntity = _userRepository.Add(userEntity);
            _userProfileRepository.Update(userProfileEntity);
            _userProfileRepository.SaveChanges();
            _userRepository.SaveChanges();
            GetUserProfileDTO getEntity = _mapper.Map<GetUserProfileDTO>(userProfileEntity);
            return new ActionStatus<GetUserProfileDTO>(getEntity);
        */
            return null;
        }
        public int SendConfirmationEmail(string emailAddress)
        {
            int code = -1;
            /*
             * отправка сообщения по емаил, возвращает код подтверждения
             */
            return code;
        }
        public int SendConfirmationSMS(string phoneNumer)
        {
            int code=-1;
            /*
             * отправка смс, возвращает код подтверждения
             */
            return code;
        }

        public bool ConfirmEmail(ConfirmUserDTO confirmUser)
        {
            User user = _userRepository.Get(confirmUser.UserId);
            if (user.EmailConfirmationCode == confirmUser.ConfirmationCode)
            {
                user.DateEmailConfirmation = DateTime.Now;
                _userRepository.Update(user);
                return true;
            }
            return false;
        }
        public bool ConfirmSMS(ConfirmUserDTO confirmUser)
        {
            User user = _userRepository.Get(confirmUser.UserId);
            if (user.SMSConfirmationCode == confirmUser.ConfirmationCode)
            {
                user.DateSMSConfirmation = DateTime.Now;
                _userRepository.Update(user);
                return true;
            }
            return false;
        }
        public bool UpdatePrivateInfo(UpdateUserProfileDTO updateEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            _userProfileRepository.Delete(id);
            _userProfileRepository.SaveChanges();
        }

    }
}
