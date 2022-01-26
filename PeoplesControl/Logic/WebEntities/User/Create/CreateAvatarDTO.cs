using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class CreateAvatarDTO
    {
        public byte[] Image { get; set; }
        public string Format { get; set; }
    }
}
