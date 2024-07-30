using MimeKit;
using System.Net.Mail;

namespace UserManagement.EmailService.Models
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }

        /// <summary>
        /// This content Will be plain text or HTML
        /// </summary>
        public string Body { get; set; }

        public bool isHtml { get; set; } = false;

       public List<Attachment> Attachments { get; set; }

        public Message(IEnumerable<string> to, string subject, string body, bool ishtml, List<Attachment> attachments = null)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress("email", x)));
            Subject = subject;
            Body = body;
            isHtml = ishtml;         
        }
    }
}
