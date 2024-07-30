using Quartz;
using UserManagement.EmailService.Models;
using UserManagement.EmailService.Services;

namespace UserManagementCoreAPI.QuartzJobSchedular
{
    public class MailSendJobSchedular : IJob
    {
        private readonly IEmailService _emailService;

        public MailSendJobSchedular(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                Message message = new Message(new string[] { "islam.rakibul@bjitgroup.com" }, "Test Mail Core 8", "Body Test mail from core 8", true, null);
                await _emailService.SendEmailAsync(message);
            }
            catch (Exception ex)
            {
                //write log here 
            }
            
        }
    }
}
