using DinkToPdf;
using WkHtmlToPdf;
using UserManagementCoreAPI.Models;

namespace UserManagementCoreAPI.Utilities
{
    public class HtmlToPdfConverter
    {
        private readonly IWebHostEnvironment _env;
        public HtmlToPdfConverter(IWebHostEnvironment env) { 
        _env = env;
        }
        public  async Task ConvertToPdf(HtmlDataModel htmlDataModel, string templateName = "EmailFormalTemplate.html")
        {
            // Get the full path of the template.html file
            var templatePath = Path.Combine(_env.ContentRootPath, "MailTemplate", templateName);

            // Read the template file
            var htmlTemplate = await File.ReadAllTextAsync(templatePath);

            //replace Name field
            var filledHtml = htmlTemplate.Replace("{Name}", htmlDataModel.Name);

            // Save the filled HTML to a temporary file
            var path = Path.GetTempPath();
            var tempHtmlPath = Path.Combine(_env.ContentRootPath,"MailTemplate", "filledTemplate.html");
            //var tempHtmlPath = Path.Combine(Path.GetTempPath(), "filledTemplate.html");
            File.WriteAllText(tempHtmlPath, filledHtml);

            // Convert HTML to PDF
            var converter = new SynchronizedConverter(new PdfTools());
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Out = "output.pdf" // Output PDF file
                },
                Objects = {
                new ObjectSettings
                {
                    Page = tempHtmlPath
                }
            }
            };

            converter.Convert(doc);

            Console.WriteLine("PDF generated successfully!");
        }
    }
}
