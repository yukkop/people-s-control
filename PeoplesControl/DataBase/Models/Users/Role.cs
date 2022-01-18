using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MnemonicName { get; set; }
        public ActionMeta Removal { get; set; }
        public ActionMeta LastEditing { get; set; }
        public ActionMeta Creation { get; set; }
    }
}
