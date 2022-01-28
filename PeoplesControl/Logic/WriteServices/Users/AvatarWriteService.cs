using AutoMapper;
using DataBase.Models;
using Logic.Helpers;
using Logic.Profiles;
using Logic.Queries;
using Logic.Repositories;
using Logic.WebEntities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logic.WriteServices
{
    public class AvatarWriteService : IAvatarWriteService
    {
        IAvatarRepository _avatarRepository;
        IAvatarQuery _avatarQuery;
        IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AvatarWriteService(IAvatarRepository avatarRepository, IMapper mapper, IAvatarQuery avatarQuery, IConfiguration configuration)
        {
            _avatarRepository = avatarRepository;
            _mapper = mapper;
            _avatarQuery = avatarQuery;
            _configuration = configuration;
        }

        public string MakeImageOnFileSystem(byte[] image, string format)
        {
            if (!format.StartsWith("."))
                format = "." + format;

            string path = _avatarQuery.LastId() + format;

            using (BinaryWriter writer = new BinaryWriter(File.Open(_configuration["GlobalMediaPath"] + path, FileMode.OpenOrCreate)))
            {
                writer.Write(image);
            };

            return path;
        }

        public RequestStatus<GetAvatarDTO> Add(CreateAvatarDTO createEntity)
        {
            Avatar entity = new Avatar();
            entity.Path = MakeImageOnFileSystem(createEntity.Image, createEntity.Format);
            entity = _avatarRepository.Add(entity);

            GetAvatarDTO getEntity = _mapper.Map<GetAvatarDTO>(entity);
            _avatarRepository.SaveChanges();
            return new RequestStatus<GetAvatarDTO>(getEntity);
        }

        public bool Update(UpdateAvatarDTO updateEntity)
        {
            Avatar entity = new Avatar();
            entity.Path = MakeImageOnFileSystem(updateEntity.Image, updateEntity.Format);
            entity = _avatarRepository.Add(entity);

            bool status = _avatarRepository.Update(entity);
            _avatarRepository.SaveChanges();
            return status;
        }

        public void Delete(long id)
        {
            AvatarDTO entity = _avatarQuery.Get(id);
            File.Delete(_configuration["GlobalMediaPath"] + entity.Path);

            _avatarRepository.Delete(id);
            _avatarRepository.SaveChanges();
        }
    }
}
