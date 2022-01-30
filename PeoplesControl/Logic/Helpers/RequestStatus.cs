using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Logic.Helpers
{
    public class RequestStatus
    {
        public enum Statuses
        {
            Ok,
            Error,
            Exeption,
            Empty,
            BadParams,
            Teapot
        }
        public Statuses Status { get; set; }
        public string StatusString { get; set; }
        public string Message { get; set; }


        public RequestStatus(Statuses status, string message)
        {
            Status = status;
            StatusString = status.ToString();
            Message = message;
        }

        public static RequestStatus ImTeapot()
        {
            return new RequestStatus(Statuses.Teapot, "I'm Teapot :(");
        }

        public static RequestStatus Ok()
        {
            return new RequestStatus(Statuses.Ok, "Кушайте не обляпайтесь");
        }

        public static RequestStatus AuthFailed()
        {
            return new RequestStatus(Statuses.BadParams, "Неправильный логин или пароль.");
        }

        public static RequestStatus Exeption(Exception e)
        {
            while (e.InnerException != null)
            {
                e = e.InnerException;
            }
            return new RequestStatus(Statuses.Exeption, e.Message);
        }
    }
    public class RequestStatus<EntityType>
    {
        public enum Statuses
        {
            Ok,
            Error,
            Exeption,
            Empty,
            BadParams,
            Teapot
        }

        public Statuses Status { get; set; }
        public string StatusString { get; set; }
        public string Message { get; set; }
        public EntityType Entity { get; set; }

        public RequestStatus(EntityType entity)
        {
            Statuses status;
            string message;

            if (entity != null)
            {
                status = Statuses.Ok;
                message = "Кушайте не обляпайтесь";
            }
            else
            {
                status = Statuses.Empty;
                message = "Сущность не найдена";
            }

            Status = status;
            StatusString = status.ToString();
            Message = message;
            Entity = entity;
        }

        public RequestStatus(EntityType entity, Statuses status, string message) 
        {
                Status = status;
            StatusString = status.ToString();
            Message = message;
                Entity = entity;
        }

        public static RequestStatus<EntityType> AuthFailed()
        {
            return new RequestStatus<EntityType>(default, Statuses.BadParams, "Неправильный логин или пароль.");
        }
    }
}
