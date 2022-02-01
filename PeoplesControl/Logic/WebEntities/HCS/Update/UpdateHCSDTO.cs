using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class UpdateHCSDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MnemonicName { get; set; }
        public string Description { get; set; }
        public long ResponsiblePersonId { get; set; }
        public long AvatarId { get; set; }
        public string Hashtag { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string MinistryEmail { get; set; }
        public long TelegramChannelId { get; set; }
        public string WebResourseURL { get; set; }
        public string AdditionalInformation { get; set; }
        public long HCSTypeId { get; set; }
        public bool IsEmailMailingEnabled { get; set; }
        public bool IsSMSMailingEnabled { get; set; }
        public bool IsDailyReportsGenerating { get; set; }
        public long UserId { get; set; }
    }
}
