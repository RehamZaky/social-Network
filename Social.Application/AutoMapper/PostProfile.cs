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
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Posts,PostDTO>().ReverseMap();
            CreateMap<Posts,PostEditDTO>().ReverseMap();
            CreateMap<Posts,CreatePostGroupDTO>().ReverseMap();
            CreateMap<Posts, PostGroupResponseDTO>().ReverseMap();
            CreateMap<GroupPosts,GroupPostDTO>().ReverseMap();
            CreateMap<PostInteractionDTO,PostInteraction>().ReverseMap();
        }
    }
}
