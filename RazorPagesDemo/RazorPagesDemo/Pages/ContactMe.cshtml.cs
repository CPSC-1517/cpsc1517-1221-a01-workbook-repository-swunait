using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace RazorPagesDemo.Pages
{
    public class ContactMeModel : PageModel
    {
        private readonly IConfiguration Configuration;

        public ContactMeModel(IConfiguration configuration)
        {
            Configuration = configuration;  
        }


        [BindProperty]
        public string? ContactName { get; set; }

        [BindProperty]
        public string? ContactEmail { get; set; }

        [BindProperty]
        public string? ContactComments { get; set; }

        [BindProperty]
        public Boolean SubscribeToMail { get; set; } = true;

        public string InfoMessage { get; private set; }

        public string ErrorMessage { get; private set; }

        public void OnPostSendMessage()
        {
            // Validate all form field values
            if (string.IsNullOrWhiteSpace(ContactName))
            {
                ModelState.AddModelError(nameof(ContactName), "Contact Name is required and cannot be blank.");
            }
            else if (ContactName.Length < 5)
            {
                ModelState.AddModelError(nameof(ContactName), "Contact Name must contain 5 or more characters.");
            }
            if (string.IsNullOrWhiteSpace(ContactEmail))
            {
                ModelState.AddModelError(nameof(ContactEmail), "Contact Email is required and cannot be blank.");
            }
            //else if(Regex.Match(ContactEmail, "\A[A-Z0-9_!#$%&'*+/=?`{|}~^.-]+@[A-Z0-9.-]+\Z").)
            if (string.IsNullOrWhiteSpace(ContactComments))
            {
                ModelState.AddModelError(nameof(ContactComments), "Contact Comments is required and cannot be blank.");
            }

            if (ModelState.IsValid)
            {
                string subscribeToMail = (SubscribeToMail == true) ? "Yes" : "No";
                InfoMessage = $"Name: {ContactName} <br />"
                    + $"Email: {ContactEmail} <br />"
                    + $"Comments: {ContactComments} <br />"
                    + $"Subscribe to mail: {subscribeToMail}";

                SmtpClient sendMailClient = new();
                sendMailClient.Host = Configuration["MailServerSettings:SmtpHost"];
                sendMailClient.Port = int.Parse(Configuration["MailServerSettings:Port"]);
                sendMailClient.EnableSsl = bool.Parse(Configuration["MailServerSettings:EnableSsl"]);

                NetworkCredential mailCredentials = new();
                mailCredentials.UserName = Configuration["MailServerSettings:Username"];
                mailCredentials.Password = Configuration["MailServerSettings:AppPassword"];
                sendMailClient.Credentials = mailCredentials;

                string mailToAddress = ContactEmail ?? Configuration["MailServerSettings:Email"];
                string mailFromAddress = Configuration["MailServerSettings:Email"];

                MailMessage mailMessage = new MailMessage(mailFromAddress, mailToAddress);
                mailMessage.Subject = "CPSC1517 new contact me form submission";
                mailMessage.Body = InfoMessage;

                try
                {
                    sendMailClient.Send(mailMessage);
                    ContactName = null;
                    ContactEmail = null;
                    ContactComments = null;
                    InfoMessage = "Your message has been sent";
                }
                catch (Exception ex)
                {
                    ErrorMessage = $"Error sending mail with exception: {ex.Message}";
                }
            }            

        }
        public IActionResult OnPostClear()
        {
            ContactName = null;
            ContactEmail = null;
            ContactComments = null;
            SubscribeToMail = true;
            return RedirectToPage();
        }

        public void OnGet()
        {
        }
    }
}
