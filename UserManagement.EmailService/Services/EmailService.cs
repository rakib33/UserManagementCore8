using MailKit.Net.Smtp;
using MimeKit;
using UserManagement.EmailService.Models;

namespace UserManagement.EmailService.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfiguration;

        /// <summary>
        /// Single Line Constructor to send email configuration
        /// </summary>
        /// <param name="emailConfiguration"></param>
        public EmailService(EmailConfiguration emailConfiguration) =>_emailConfiguration= emailConfiguration;

        public async Task SendEmailAsync(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfiguration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            var bodyBuilder = new BodyBuilder
            {
                TextBody = message.isHtml ? null : message.Body,
                HtmlBody = message.isHtml ? message.Body : null
            };
            //bodyBuilder.Attachments = message.Attachments;

            //if (attachment != null)
            //{
            //    using (var ms = new MemoryStream())
            //    {
            //        await attachment.CopyToAsync(ms);
            //        builder.Attachments.Add(attachment.FileName, ms.ToArray(), ContentType.Parse(attachment.ContentType));
            //    }
            //}
            //if (message.Attachments != null)
            //{
            //    foreach (var attachment in message.Attachments)
            //    {
            //        bodyBuilder.Attachments.Add(attachment.Filename, attachment.Data, ContentType.Parse(attachment.ContentType));
            //    }
            //}

            emailMessage.Body = bodyBuilder.ToMessageBody();

           await SendAsync(emailMessage);
            //using (MailKit.Net.Smtp.SmtpClient mailClient = new MailKit.Net.Smtp.SmtpClient())
            //{
            //    mailClient.Connect("bd1.bjitgroup.com", _emailSettings.SmtpPort, useSsl: true);
            //    mailClient.Authenticate("bjittest.cwasa", _emailSettings.SmtpPass);
            //    //Log.Information($"Sending mail to {toEmail}");
            //    var r = mailClient.Send(message);
            //    // Log.Information($"Mail response: {r}");
            //    mailClient.Disconnect(true);
            //    //  Log.Information($"Disconnected: {r}");
            //}
        }
        public async void SendMail(Message message)
        {
            var emailMesssage = CreateEmailMessage(message);
            await SendAsync(emailMesssage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfiguration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Body };
            return emailMessage;        
         }

        private async Task SendAsync(MimeMessage message)
        {

            using var client = new SmtpClient();
            //using (var client = new SmtpClient())
            //{
            try
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                //  client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                //  client.Connect("smtp.server.com", 587, false);
                client.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.Port, useSsl:true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfiguration.UserName, _emailConfiguration.Password);

              await  client.SendAsync(message);

                //  }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
