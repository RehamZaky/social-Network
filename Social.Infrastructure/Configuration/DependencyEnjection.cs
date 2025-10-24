using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Social.Application.Services.Interface;
using Social.Application.Services.Repository;
using Social.Domain.Interface;
using Social.Infrastructure.Presestance.Data;
using Social.Infrastructure.Presestance.Repository;


namespace Social.Infrastructure.Configuration
{
    public static class DependencyEnjection
    {
        public static IServiceCollection ConfigureDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IPostRepository,PostRepository>(); 
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IPageRepository,PageRepository>();
            services.AddScoped<IGroupRepository,GroupRepository>();
            services.AddScoped<ICommentRepository,CommentRepository>();

            return services;

        }

        public static WebApplication AddInfrastructureWeb(this WebApplication app)
        {
            // http request pipeline
            return app;
        }
    }
}
