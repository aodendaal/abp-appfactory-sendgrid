using Abp.AppFactory.Interfaces;
using Abp.AppFactory.SendGrid.Configuration;
using SendGrid;
using System.Threading.Tasks;

namespace Abp.AppFactory.SendGrid
{
    public class SendGrid : ISendGrid
    {
        private SendGridClient Client { get; set; }

        public SendGrid(SendGridConfiguration config)
        {
            Client = new SendGridClient(config.SendGridKey);
        }

        public Task<ISendGridResponse> SendAsync(IEmail email) => SendAsync(email);

        public async Task<SendGridResponse> SendAsync(Email email)
        {
            return new SendGridResponse(await Client.SendEmailAsync(email.ToMessage()));
        }
    }
}