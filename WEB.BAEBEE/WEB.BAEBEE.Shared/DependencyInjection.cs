using Microsoft.Extensions.DependencyInjection;
using WEB.BAEBEE.Shared.Interface;
using WEB.BAEBEE.Shared.Helper;

namespace WEB.BAEBEE.Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterShared(this IServiceCollection services)
        {
            services.AddSingleton<IGeneralHelper, GeneralHelper>();
            services.AddSingleton<IWrapperHelper, WrapperHelper>();
            services.AddSingleton<IHttpRequest, HttpRequest>();

            return services;
        }
    }
}
