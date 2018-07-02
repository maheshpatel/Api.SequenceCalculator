using System.Collections.Generic;

namespace Api.SequenceCalculator.Service
{
    public interface ISequenceGeneratorStrategy
    {
        List<string> GenerateSequenceNumbers(int number);
    }
}