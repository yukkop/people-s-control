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

        public RequestStatus RegistrationByEmail(RegistrationByEmailDTO registrationEntity)
        {
            if (registrationEntity.DistrictId == null || registrationEntity.DistrictId == 0)
                return new RequestStatus(RequestStatus.Statuses.BadParams, "Не заполненно поле Район (Фронтэндер даун)");

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
            userEntity.EmailConfirmationCode = MakeConfirmationCode();
            userEntity = _userRepository.Add(userEntity);

            Exception exception = _userRepository.SaveChanges();
            if (exception != null)
            {
                return RequestStatus.Exeption(exception);
            }

            SendConfirmationEmail(userProfileEntity.EmailAddress, (int)userEntity.EmailConfirmationCode);

            return RequestStatus.Ok();
        }
        public void SendConfirmationEmail(string emailAddress, int code)
        {

            MailAddress from = new MailAddress(_configuration["ServerEmailAddress"], "People-s-control");
            MailAddress to = new MailAddress(emailAddress);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Подтверждение People-s-control";
            m.Body = "<h2>Ниже представлен код подтверждения регистрации на портале People-s-Control</h2>" +
                "<br>Скопируйте его в форму регистрации для завершения <br>";
            m.IsBodyHtml = true;
            m.Body += code.ToString();
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            // логин и пароль
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_configuration["ServerEmailAddress"], _configuration["ServerEmailPassword"]);
            smtp.EnableSsl = true;
            smtp.Send(m);
        }

        private int MakeConfirmationCode()
        {
            int code;
            byte[] a = _authenticationService.SaltGen();
            byte[] b = new byte[4];
            Array.Copy(a, b, 4);
            code = BitConverter.ToInt32(b);
            code = Math.Abs(code);

            return code;
        }
        private int SendConfirmationSMS(string phoneNumer)
        {
            int code=-1;
            /*
             * отправка смс, возвращает код подтверждения
             */
            return code;
        }

        public RequestStatus ResendConfirmationCodeEmail(long userId)
        {
            User user = _userRepository.Get(userId);
            UserProfile userProfile = _userProfileRepository.Get(user.UserProfileId);

            if (userProfile.EmailAddress == null)
            {
                return new RequestStatus(RequestStatus.Statuses.BadParams, "У этого пользователя нет почты");
            }

            user.EmailConfirmationCode = MakeConfirmationCode();
            _userRepository.Update(user);

            Exception exception = _userRepository.SaveChanges();
            if (exception != null)
            {
                return RequestStatus.Exeption(exception);
            }

            SendConfirmationEmail(userProfile.EmailAddress, (int)user.EmailConfirmationCode);
            return RequestStatus.Ok();
        }

        public RequestStatus ConfirmEmail(long userID, int confirmationCode)
        {
            User user = _userRepository.Get(userID);
            if (user.EmailConfirmationCode == confirmationCode)
            {
                user.DateEmailConfirmation = DateTime.Now;
                _userRepository.Update(user);
                _userProfileRepository.SaveChanges();
                return RequestStatus.Ok();
            }
            return new RequestStatus(RequestStatus.Statuses.BadParams, "Неверный код подтверждения");
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
