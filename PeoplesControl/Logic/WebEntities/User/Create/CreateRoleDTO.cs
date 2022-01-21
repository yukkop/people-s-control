using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class CreateRoleDTO
    {
        public string Name { get; set; }
        public string MnemonicName { get; set; }
        public long UserId { get; set; }
    }
}
