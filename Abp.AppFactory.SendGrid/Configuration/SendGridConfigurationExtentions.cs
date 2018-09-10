using Abp.Configuration.Startup;

namespace Abp.AppFactory.SendGrid.Configuration
{
    public static class SendGridConfigurationExtensions
    {
        public static SendGridConfiguration SendGridConfiguration(this IModuleConfigurations moduleConfigurations)
        {
            return moduleConfigurations.AbpConfiguration.Get<SendGridConfiguration>();
        }
    }
}