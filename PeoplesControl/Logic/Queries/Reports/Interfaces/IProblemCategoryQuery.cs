using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Queries
{
    public interface IProblemCategoryQuery
    {
        public ProblemCategoryDTO Get(long id);
        public List<ProblemCategoryDTO> GetAll();
    }
}
