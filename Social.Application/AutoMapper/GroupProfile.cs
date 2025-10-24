using AutoMapper;
using Social.Application.DTO;
using Social.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.AutoMapper
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {

            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<Group, GroupEditDTO>().ReverseMap();
        }
    }
             
}
