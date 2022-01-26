using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class ProblemCategoryDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MnemonicName { get; set; }
        public string HashTag { get; set; }
        public long AvatarId { get; set; }
        public Avatar Avatar { get; set; }
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }
        // public float Rate { get; set; } запросом сделай
        public ActionMeta Removal { get; set; }
        public long RemovalId { get; set; }
        public ActionMeta LastEditing { get; set; }
        public long LastEditingId { get; set; }
        public ActionMeta Creation { get; set; }
        public long CreationId { get; set; }
    }
}
