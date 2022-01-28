using AutoMapper;
using Logic.Helpers;
using Logic.Profiles;
using Logic.Queries;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public class ProblemCategoryReadService : IProblemCategoryReadService
    {
        IProblemCategoryQuery _reportQuery;
        private readonly IMapper _mapper;
        public ProblemCategoryReadService(IProblemCategoryQuery reportQuery, IMapper mapper)
        {
            _reportQuery = reportQuery;
            _mapper = mapper;
        }

        public RequestStatus<GetProblemCategoryDTO> Get(long id)
        {
            ProblemCategoryDTO entity = _reportQuery.Get(id);
            return new RequestStatus<GetProblemCategoryDTO>(_mapper.Map<GetProblemCategoryDTO>(entity));
        }
        public RequestStatus<List<GetProblemCategoryDTO>> GetAll()
        {
            List<ProblemCategoryDTO> entities = _reportQuery.GetAll();
            List<GetProblemCategoryDTO> getEntities = new List<GetProblemCategoryDTO>();

            foreach (var entity in entities)
            {
                getEntities.Add(_mapper.Map<GetProblemCategoryDTO>(entity));
            }

            return new RequestStatus<List<GetProblemCategoryDTO>>(getEntities);
        }
    }
}

