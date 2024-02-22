using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using WEB.BAEBEE.Infrastructure.Mail.Interface;
using WEB.BAEBEE.Infrastructure.Mail.Service;
using WEB.BAEBEE.Infrastructure.Mail.Object;

namespace WEB.BAEBEE.Infrastructure.Mail
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterMail(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailConfig>(options => configuration.Bind(nameof(MailConfig), options));
            services.AddTransient<IEmailService, EmailService>();
            
            return services;
        }
    }
}
