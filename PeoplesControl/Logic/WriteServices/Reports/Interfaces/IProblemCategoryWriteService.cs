using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public interface IProblemCategoryWriteService
    {
        public ActionStatus<GetProblemCategoryDTO> Add(CreateProblemCategoryDTO createEntity);
        public bool Update(UpdateProblemCategoryDTO updateEntity);
        public void Delete(long id, long userId);
    }
}
