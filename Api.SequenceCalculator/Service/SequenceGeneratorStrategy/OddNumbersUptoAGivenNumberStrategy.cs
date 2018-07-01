using System.Collections.Generic;
using System.Linq;

namespace Api.SequenceCalculator.Service
{
    public class OddNumbersUptoAGivenNumberStrategy : ISequenceGeneratorStrategy
    {
        public List<string> GenerateSequenceNumbers(int number)
        {
            if (number <= 0)
                return null;

            return Enumerable.Range(1, number).Where(num => num % 2 != 0).Select(num => num.ToString()).ToList();
        }
    }
}