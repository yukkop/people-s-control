using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public interface IProblemCategoryReadService
    {
        public RequestStatus<GetProblemCategoryDTO> Get(long id);
        public RequestStatus<List<GetProblemCategoryDTO>> GetAll();
    }
}
