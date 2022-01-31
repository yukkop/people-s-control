using AutoMapper;
using Logic.Helpers;
using Logic.Queries;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logic.ReadServices
{
    public class UserProfileReadService : IUserProfileReadService
    {
        IUserProfileQuery _userProfileQuery;
        private readonly IMapper _mapper;
        public UserProfileReadService(IUserProfileQuery userProfileQuery, IMapper mapper)
        {
            _userProfileQuery = userProfileQuery;
            _mapper = mapper;
        }
        public RequestStatus<GetUserProfileDTO> Get(long id)
        {
            UserProfileDTO entity = _userProfileQuery.Get(id);
            //entity.Avatar = System.IO.File.ReadAllBytes(entity.AvatarPath);

            return new RequestStatus<GetUserProfileDTO>(_mapper.Map<GetUserProfileDTO>(entity));
        }
    }
}
