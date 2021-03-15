using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MouseHouse.Models
{
    public class EmailSender
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

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // get the sendgrid api key
            var sendGridKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            return Execute(sendGridKey, subject, htmlMessage, email);
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
