using System.Net.Mail;
using UserManagement.EmailService.Models;

namespace UserManagement.EmailService.Services
{
    public interface IEmailService
    {
        void SendMail(Message message);
        Task SendEmailAsync(Message message);
    }
}
