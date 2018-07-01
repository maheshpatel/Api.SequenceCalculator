using System.Collections.Generic;
using System.Linq;

namespace Api.SequenceCalculator.Service
{
    public class FizzBuzzSequenceNumberStrategy : ISequenceGeneratorStrategy
    {
        public List<string> GenerateSequenceNumbers(int number)
        {
            if (number <= 0)
                return null;

            return Enumerable.Range(1, number).Select(num => (num % 3 == 0 && num % 5 == 0) ? "Z" 
                                                : num % 3 == 0 ? "C" : num % 5 == 0 ? "E" : num.ToString()).ToList();
        }
    }
}