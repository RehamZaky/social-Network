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
    public class CommentProfile : Profile
    {

        public CommentProfile() {
            CreateMap<Comment, CommentDTO>().ReverseMap();
            CreateMap<Comment, CommentEditDTO>().ReverseMap();
            CreateMap<Comment,ReplyDTO>().ReverseMap();

        
        }
    }
}
