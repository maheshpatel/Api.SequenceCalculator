using System;
using System.Collections.Generic;
using System.Web;

namespace Api.SequenceCalculator.Service
{
    public interface ISequenceGeneratorStrategy
    {
        List<string> GenerateSequenceNumbers(int number);
    }
}