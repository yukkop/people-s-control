using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class CreateProblemCategoryDTO
    {
        public string Name { get; set; }
        public string MnemonicName { get; set; }
        public string HashTag { get; set; }
        public long AvatarId { get; set; }
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }
        // public float Rate { get; set; } запросом сделай
        public long UserId { get; set; }
    }
}
