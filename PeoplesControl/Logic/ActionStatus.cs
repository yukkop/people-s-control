using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Helpers
{
    public class ActionStatus<EntityType>
    {
        public string StatusString { get; set; }
        public EntityType Entity { get; set; }        
        public ActionStatus(EntityType entity)
        {
            if (entity != null)
                StatusString = "Ok";
            else
                StatusString = "Object is null";
            Entity = entity;
        }
    }
}
