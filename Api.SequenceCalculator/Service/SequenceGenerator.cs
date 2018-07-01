using System.Collections.Generic;

namespace Api.SequenceCalculator.Service
{
    public class SequenceGenerator : ISequenceGenerator
    {
        public List<string> GenerateSequenceFor(int number, ISequenceGeneratorStrategy sequenceGeneratorStrategy)
        {
            return sequenceGeneratorStrategy.GenerateSequenceNumbers(number);
        }
    }

    public interface ISequenceGenerator
    {
        List<string> GenerateSequenceFor(int number, ISequenceGeneratorStrategy sequenceGeneratorStrategy);
    }
}