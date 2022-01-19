using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IProblemCategoryRepository
    {
        public ProblemCategory Get(int id);
        public List<ProblemCategory> GetAll();
        public ProblemCategory Add(ProblemCategory problemCategory);
    }
}
