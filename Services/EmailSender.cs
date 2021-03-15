using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MouseHouse.Services
{
    public class EmailSender : IEmailSender
    {
        /// <summary>
        /// Offical email account for the MouseHouse enterprise
        /// and SendGrid's verified single sender
        /// </summary>
        const string MouseHouseEmail = "mousehouseenterprise@gmail.com";
        /// <summary>
        /// Name attached to the offical email account for the MouseHouse enterprise
        /// </summary>
        const string MouseHouseName = "MouseHouse Support";

        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }
        public AuthMessageSenderOptions Options { get; } // set only viea Secret Manager

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(Options.SendGridKey, subject, htmlMessage, email);
        }


        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(MouseHouseEmail, MouseHouseName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}
