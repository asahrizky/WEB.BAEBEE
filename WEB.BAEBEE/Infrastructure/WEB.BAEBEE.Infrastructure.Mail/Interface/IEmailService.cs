using WEB.BAEBEE.Infrastructure.Mail.Object;

namespace WEB.BAEBEE.Infrastructure.Mail.Interface
{
    public interface IEmailService
    {
        Task<(bool Success, string Message, Exception ex)> SendMail(List<string> to, List<string> cc, string subject, string body, List<AttachmentMail> attachments);
        bool IsValidEmail(string email);
    }
}
