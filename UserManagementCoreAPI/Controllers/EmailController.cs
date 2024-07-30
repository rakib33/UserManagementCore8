using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.EmailService.Models;
using UserManagement.EmailService.Services;
using UserManagementCoreAPI.Models;
using UserManagementCoreAPI.Utilities;

namespace UserManagementCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly HtmlToPdfConverter _htmlToPdfConverter;        
        public EmailController(IEmailService emailService, HtmlToPdfConverter htmlToPdfConverter)
        {
            _emailService = emailService;
            _htmlToPdfConverter = htmlToPdfConverter;
        }

        [HttpPost("html-to-pdf-converter")]
        public async void HtmlToPdf()
        {
            HtmlDataModel model = new HtmlDataModel();
            model.Name = "Test Mail";
            await _htmlToPdfConverter.ConvertToPdf(model, "EmailFormalTemplate.html");
        }
        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromForm] List<string> to, [FromForm] string subject, [FromForm] string body, [FromForm] List<IFormFile> Attachments)
        {
            Message message = new Message(to,subject,body,true);
            message.Attachments = new List<Attachment>();
            if (Attachments != null)
            {
                foreach (var file in Attachments)
                {
                    using (var stream = new MemoryStream())
                    {
                        //convert file to memory Stream
                        file.CopyTo(stream);
                        //fileDetails.FileData = stream.ToArray();
                        message.Attachments.Add(new Attachment { Filename = file.FileName, Data = stream, ContentType = file.ContentType });
                    }                   
                }
            }

            await _emailService.SendEmailAsync(message);

            return Ok();
        }
    }
}
