using Api.SequenceCalculator.Service;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;

namespace Api.SequenceCalculator
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;


            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterType<SequenceCalculatorService>().
                As<ISequenceCalculatorService>().InstancePerRequest();

            builder.RegisterType<SequenceGenerator>().
               As<ISequenceGenerator>().InstancePerRequest();

            builder.RegisterType<AllNumbersUptoAGivenNumberStrategy>().
                    As<ISequenceGeneratorStrategy>().
                    Keyed<ISequenceGeneratorStrategy>(SequenceType.AllNumbers);


            builder.RegisterType<EvenNumbersUptoAGivenNumberStrategy>().
                    As<ISequenceGeneratorStrategy>().
                    Keyed<ISequenceGeneratorStrategy>(SequenceType.EvenNumbers);

            builder.RegisterType<OddNumbersUptoAGivenNumberStrategy>().
                    As<ISequenceGeneratorStrategy>().
                    Keyed<ISequenceGeneratorStrategy>(SequenceType.OddNumbers);

            builder.RegisterType<FizzBuzzSequenceNumberStrategy>().
                    As<ISequenceGeneratorStrategy>().
                    Keyed<ISequenceGeneratorStrategy>(SequenceType.FizzBuzzNumbers);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            WebApiConfig.Register(config);
            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}
