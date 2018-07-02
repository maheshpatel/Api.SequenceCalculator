
using Api.SequenceCalculator.Service;
using Autofac;

namespace Api.SequenceCalculator.Tests
{
    public static class ContainerTest
    {
        public static IContainer InitialisedContainer
        {
            get
            {
                var builder = new ContainerBuilder();
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

                return builder.Build();

            }
        }

    }
}
 