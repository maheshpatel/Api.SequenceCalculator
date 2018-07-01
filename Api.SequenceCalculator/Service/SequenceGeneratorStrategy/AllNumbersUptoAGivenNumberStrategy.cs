using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.SequenceCalculator.Service
{
    public class AllNumbersUptoAGivenNumberStrategy : ISequenceGeneratorStrategy
    {
        public List<string> GenerateSequenceNumbers(int number)
        {
            if (number <= 0)
                return null;

            return Enumerable.Range(1, number).Select(num => num.ToString()).ToList();
        }
    }
}