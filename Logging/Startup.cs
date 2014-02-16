using Common;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;

namespace Logging
{
    public class Startup :NinjectModule
    {
        public override void Load()
        {
            Bind<IService>().To<Service>().Intercept().With<LoggingInterceptor>();
        }
    }
}
