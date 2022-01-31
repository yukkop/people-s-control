using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public interface IHCSWriteService
    {
        public RequestStatus Create(CreateHCSDTO createEntity, long userId);
        public bool Update(UpdateHCSDTO updateEntity, long userId);
        public void Delete(long id, long userId);
        public bool UpdateResponsiblePerson(long hCSId, long userId, long responsiblePersonId);
    }
}
