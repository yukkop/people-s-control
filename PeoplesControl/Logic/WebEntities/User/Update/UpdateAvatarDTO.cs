using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class UpdateAvatarDTO
    {
        public long Id { get; set; }
        public byte[] Image { get; set; }
        public string Format { get; set; }
    }
}
