using Project.Models.DTOs.EmailDTO;

namespace Project.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO request);
    }
}
