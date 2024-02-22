using WEB.BAEBEE.Web.Services.User;

namespace WEB.BAEBEE.Web.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
