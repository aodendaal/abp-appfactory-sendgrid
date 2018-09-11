using Abp.AppFactory.Interfaces;
using Abp.AppFactory.SendGrid.Configuration;
using Abp.AppFactory.SendGrid.Email;
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

        public async Task<ISendGridResponse> SendAsync(ISendGridEmail email) => new SendGridResponse(await Client.SendEmailAsync(email.ToMessage()));
    }
}