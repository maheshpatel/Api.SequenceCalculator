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
                AllNumbersUptoGivenNumber = _sequenceGenerator.GenerateSequenceFor(number, new AllNumbersUptoAGivenNumberStrategy()),
                EvenNumbersUptoGivenNumber = _sequenceGenerator.GenerateSequenceFor(number, new EvenNumbersUptoAGivenNumberStrategy()),
                OddNumbersUptoGivenNumber = _sequenceGenerator.GenerateSequenceFor(number, new OddNumbersUptoAGivenNumberStrategy()),
                FizzBuzzSequenceNumbersUptoGivenNumber = _sequenceGenerator.GenerateSequenceFor(number, new FizzBuzzSequenceNumberStrategy())
            };

            return sequenceNumbers;
        }
    }

    public interface ISequenceCalculatorService
    {
        SequenceNumbers CalculateSequence(int number);
    }
}