using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.SequenceCalculator.Models
{
    public class SequenceNumbers
    {
        public List<string> AllNumbersUptoGivenNumber { get; set; }
        public List<string> OddNumbersUptoGivenNumber { get; set; }
        public List<string> EvenNumbersUptoGivenNumber { get; set; }
        public List<string> FizzBuzzSequenceNumbersUptoGivenNumber { get; set; }
    }
}