using Api.SequenceCalculator.Models;

namespace Api.SequenceCalculator.Service
{
    public class SequenceCalculatorService : ISequenceCalculatorService
    {
        private readonly ISequenceGenerator _sequenceGenerator;

        public SequenceCalculatorService(ISequenceGenerator sequenceGenerator)
        {
            _sequenceGenerator = sequenceGenerator;
        }

        public SequenceNumbers CalculateSequence(int number)
        {
            var sequenceNumbers = new SequenceNumbers
            {
                AllNumbersUptoGivenNumber = _sequenceGenerator.GenerateSequenceFor(number, SequenceType.AllNumbers),
                EvenNumbersUptoGivenNumber = _sequenceGenerator.GenerateSequenceFor(number, SequenceType.EvenNumbers),
                OddNumbersUptoGivenNumber = _sequenceGenerator.GenerateSequenceFor(number, SequenceType.OddNumbers),
                FizzBuzzSequenceNumbersUptoGivenNumber = _sequenceGenerator.GenerateSequenceFor(number, SequenceType.FizzBuzzNumbers)
            };

            return sequenceNumbers;
        }
    }

    public interface ISequenceCalculatorService
    {
        SequenceNumbers CalculateSequence(int number);
    }

    public enum SequenceType
    {
        AllNumbers,
        EvenNumbers,
        OddNumbers,
        FizzBuzzNumbers
    }
}