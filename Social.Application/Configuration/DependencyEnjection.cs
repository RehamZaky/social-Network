using Microsoft.Extensions.DependencyInjection;
using Social.Application.Services.Interface;
using Social.Application.Services.Repository;
using Social.Application.Services.Service;

namespace Social.Application.Configuration
{
    public static class DependencyEnjection
    {
        public static IServiceCollection configureApplication(this IServiceCollection services)
        {
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IPageService, PageService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IHashtagService, HashtagService>();
            services.AddScoped<IFriendService, FriendService>();
            return services;
        }

        //public static WebApplication confWebApp(this WebApplication webApplication)
        //{
        //    return webApplication;
        //}
    }
}
