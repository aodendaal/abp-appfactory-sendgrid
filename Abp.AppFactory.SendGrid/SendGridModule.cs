using Abp.AppFactory.Interfaces;
using Abp.AppFactory.SendGrid.Configuration;
using Abp.Dependency;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Abp.AppFactory.SendGrid
{
    public class SendGridModule : AbpModule
    {
        private readonly IHostingEnvironment env;
        private IConfigurationRoot _appConfiguration;

        public SendGridModule(IHostingEnvironment env)
        {
            this.env = env;
        }

        public override void PreInitialize()
        {
            IocManager.Register<SendGridConfiguration>();

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");

            _appConfiguration = builder.Build();

            Configuration.Modules.SendGridConfiguration().SendGridKey = _appConfiguration["SendGrid:Key"];
            IocManager.Register<ISendGrid, SendGrid>(DependencyLifeStyle.Transient);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SendGridModule).GetAssembly());
        }
    }
}