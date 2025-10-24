using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models.ExternalConnectors;
using Social.Application.AutoMapper;
using Social.Application.Validation;
using Social.Infrastructure.Presestance.Data;

namespace Social.Api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services,IConfiguration configuration)
        {
            //DB connection
            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAutoMapper(typeof(UserProfile).Assembly);    // cleaner and fast
         //   services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddValidatorsFromAssemblyContaining<PostValidation>();


            return services;
        }

    }
}
