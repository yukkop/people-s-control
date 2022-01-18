using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Web_Entities
{
    public class CreateRoleDTO
    {
        public string Name { get; set; }
        public string MnemonicName { get; set; }
        public long RemovalId { get; set; }
        public long LastEditingId { get; set; }
        public long CreationId { get; set; }
    }
}
