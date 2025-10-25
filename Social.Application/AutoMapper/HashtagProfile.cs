using AutoMapper;
using Social.Application.DTO;
using Social.Domain.Data;
using Social.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.AutoMapper
{
    public class HashtagProfile :Profile
    {
        public HashtagProfile() { 
            CreateMap<HashtagDto,Hashtag>().ReverseMap();
            CreateMap<UpdateHashtagDto, Hashtag>().ReverseMap();
            CreateMap<HashtagPostDTO, Posts>().ReverseMap();
        }
    }
}
