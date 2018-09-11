using Abp.AppFactory.Interfaces;
using SendGrid.Helpers.Mail;

namespace Abp.AppFactory.SendGrid.Email
{
    public class SendGridEmail : ISendGridEmail
    {
        public string SenderEmailAddress { get;  set; }
        public string SenderName { get; set; }
        public string SubjectContent { get; set; }
        public string BodyTextContent { get; set; }
        public string BodyHtmlContent { get; set; }
        public string RecepientEmailAddress { get; set; }
        public string RecepientName { get; set; }
    }

    internal static class EmailExtentions
    {
        internal static SendGridMessage ToMessage(this ISendGridEmail email)
        {
            var message = new SendGridMessage()
            {
                From = new EmailAddress(email.SenderEmailAddress, email.SenderName),
                Subject = email.SubjectContent,
                PlainTextContent = email.BodyTextContent,
                HtmlContent = email.BodyHtmlContent
            };

            message.AddTo(new EmailAddress(email.RecepientEmailAddress, email.RecepientName));
            return message;
        }
    }
}