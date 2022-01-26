using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public interface IProblemCategoryReadService
    {
        public ActionStatus<GetProblemCategoryDTO> Get(long id);
        public ActionStatus<List<GetProblemCategoryDTO>> GetAll();
    }
}
