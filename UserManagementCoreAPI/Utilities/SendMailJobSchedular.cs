using UserManagement.EmailService.Services;
using UserManagementCoreAPI.Models;

namespace UserManagementCoreAPI.Utilities
{
    public class SendMailJobSchedular
    {
        private readonly IEmailService _emailService;
       private readonly HtmlToPdfConverter _htmlToPdfConverter;
        public SendMailJobSchedular(IEmailService emailService) 
        {       
         _emailService = emailService;        
        }

        public async void SendMail()
        {
            HtmlDataModel model = new HtmlDataModel();
            model.Name = "Test Mail";
           await _htmlToPdfConverter.ConvertToPdf(model, "EmailFormalTemplate.html");
        }
    }
}
