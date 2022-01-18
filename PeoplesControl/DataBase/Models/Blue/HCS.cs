using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class HCS
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MnemonicName { get; set; }
        public string Description { get; set; }
        public User ResponsiblePerson { get; set; }
        public Avatar Avatar { get; set; }
        public string Hashtag { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string MinistryEmail { get; set; }
        public long TelegramChannelId { get; set; }
        public string WebResourseURL { get; set; }
        public string AdditionalInformation { get; set; }
        public HCSType HCSType { get; set; }
        public bool IsEmailMailingEnabled { get; set; }
        public bool IsSMSMailingEnabled { get; set; }
        public bool IsDailyReportsGenerating { get; set; }
        public bool IsVisible { get; set; }
        public ActionMeta Removal { get; set; }
        public ActionMeta LastEditing { get; set; }
        public ActionMeta Creation { get; set; }
    }
}
