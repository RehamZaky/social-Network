using FluentValidation;
using Social.Application.DTO;
using Social.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.Validation
{
    public class PostValidation : AbstractValidator<PostDTO>
    {
        public PostValidation() { 
             RuleFor(i=> i.Content).NotEmpty().MinimumLength(2);
        
        }
    }
}
