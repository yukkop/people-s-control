using AutoMapper;
using DataBase.Models;
using Logic.Helpers;
using Logic.Profiles;
using Logic.Repositories;
using Logic.WebEntities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Logic.WriteServices
{
    public class UserProfileWriteService : IUserProfileWriteService
    {
        IUserProfileRepository _userProfileRepository;
        IAuthenticationService _authenticationService;
        IActionMetaRepository _actionMetaRepository;
        IUserRepository _userRepository;
        IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserProfileWriteService(IUserProfileRepository userProfileRepository, 
                                        IUserRepository userRepository, 
                                        IConfiguration configuration,
                                        IActionMetaRepository actionMetaRepository,
                                        IAuthenticationService authenticationService, 
                                        IMapper mapper)
        {
            _userProfileRepository = userProfileRepository;
            _userRepository = userRepository;
            _actionMetaRepository = actionMetaRepository;
            _configuration = configuration;
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        public bool RegistrationByEmail(RegistrationByEmailDTO registrationEntity)
        {
            if (registrationEntity.DistrictId == null)
                return false;

            UserProfile userProfileEntity = _mapper.Map<UserProfile>(registrationEntity);

            ActionMeta creation = new ActionMeta()
            {
                UserId = 2,
                Date = DateTime.Now
            };
            creation = _actionMetaRepository.Add(creation);
            userProfileEntity.Creation = creation;
            userProfileEntity = _userProfileRepository.Add(userProfileEntity);

            User userEntity = new User();
            userEntity.Login = registrationEntity.EmailAddress;
            userEntity.SaltValue = _authenticationService.SaltGen();
            userEntity.SaltPassword = _authenticationService.SaltHash(registrationEntity.Password, userEntity.SaltValue);

            userEntity.UserProfile = userProfileEntity;
            userEntity.EmailConfirmationCode = SendConfirmationEmail(userProfileEntity.EmailAddress);
            userEntity = _userRepository.Add(userEntity);

            /*
             * Почта телефон подтверждение?
             */

            _userRepository.SaveChanges();
            
            return true ;
        }
        public int SendConfirmationEmail(string emailAddress)
        {
            int code = -1;

            MailAddress from = new MailAddress(_configuration["ServerEmailAddress"], "People-s-control");
            MailAddress to = new MailAddress(emailAddress);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Подтверждение People-s-control";
            m.Body = "<h2>Ниже представлен код подтверждения регистрации на портале People-s-Control</h2>" +
                "<br>Скопируйте его в форму регистрации для завершения <br>";
            m.IsBodyHtml = true;
            byte[] a = _authenticationService.SaltGen();
            byte[] b = new byte[4];
            Array.Copy(a, b, 4);
            code = BitConverter.ToInt32(b);
            code = Math.Abs(code);
            m.Body += code.ToString();
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            // логин и пароль
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_configuration["ServerEmailAddress"], _configuration["ServerEmailPassword"]);
            smtp.EnableSsl = true;
            smtp.Send(m);


            return code;
        }

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

        public int SendConfirmationSMS(string phoneNumer)
        {
            int code=-1;
            /*
             * отправка смс, возвращает код подтверждения
             */
            return code;
        }

        public bool ConfirmEmail(long userID, int confirmationCode)
        {
            User user = _userRepository.Get(userID);
            if (user.EmailConfirmationCode == confirmationCode)
            {
                user.DateEmailConfirmation = DateTime.Now;
                _userRepository.Update(user);
                _userProfileRepository.SaveChanges();
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
