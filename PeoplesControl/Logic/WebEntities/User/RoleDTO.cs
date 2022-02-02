using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class RoleDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MnemonicName { get; set; }

        #region Actions
        public long RemovalActionId { get; set; }
        public long UserMadeRemovalId { get; set; }
        public DateTime DateRemoval { get; set; }
        public long LastEditingActionId { get; set; }
        public long UserMadeLastEditingId { get; set; }
        public DateTime DateLastEditing { get; set; }
        public long CreationActionId { get; set; }
        public long UserMadeCreationId { get; set; }
        public DateTime DateCreation { get; set; }
        #endregion
    }
}
