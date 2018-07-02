using Autofac;
using System.Collections.Generic;

namespace Api.SequenceCalculator.Service
{
    public class SequenceGenerator : ISequenceGenerator
    {
        private readonly ILifetimeScope _lifeTimeScope;
        public SequenceGenerator(ILifetimeScope lifetimeScope)
        {
            _lifeTimeScope = lifetimeScope;
        }
        public List<string> GenerateSequenceFor(int number, SequenceType sequenceType)
        {
            var sequenceGeneratorStrategy = _lifeTimeScope.ResolveKeyed<ISequenceGeneratorStrategy>(sequenceType);
            return sequenceGeneratorStrategy.GenerateSequenceNumbers(number);
        }
    }

    public interface ISequenceGenerator
    {
        List<string> GenerateSequenceFor(int number, SequenceType sequenceType);
    }
}