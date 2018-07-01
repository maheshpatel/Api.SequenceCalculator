using Api.SequenceCalculator.Models;
using Api.SequenceCalculator.Service;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace Api.SequenceCalculator.Tests.Service
{
    [TestFixture]
    public class SequenceCalculatorTests
    {
        private ISequenceGenerator _sequenceGenerator;
        private SequenceCalculatorService _sequenceCalculatorService;

        [SetUp]
        public void Setup()
        {
            _sequenceGenerator = Substitute.For<ISequenceGenerator>();
            _sequenceCalculatorService = new SequenceCalculatorService(_sequenceGenerator);
        }

        [Test]
        public void SequenceCalculatorServiceReturns_SequenceOf_Odd_Even_AllNumbers_And_FizzBuzzSequence()
        {
            var expectedSequenceNumbers = new SequenceNumbers()
            {
                AllNumbersUptoGivenNumber = new List<string> { "1", "2", "3", "4", "5" },
                EvenNumbersUptoGivenNumber = new List<string> { "2", "4" },
                OddNumbersUptoGivenNumber = new List<string> { "1", "3", "5" },
                FizzBuzzSequenceNumbersUptoGivenNumber = new List<string> { "1", "2", "C", "4", "E" }
            };

            _sequenceGenerator.GenerateSequenceFor(5, Arg.Is<ISequenceGeneratorStrategy>(x => x is EvenNumbersUptoAGivenNumberStrategy)).
                                    Returns(new List<string> { "2", "4" });
            _sequenceGenerator.GenerateSequenceFor(5, Arg.Is<ISequenceGeneratorStrategy>(x => x is OddNumbersUptoAGivenNumberStrategy)).
                                    Returns(new List<string> { "1", "3", "5" });
            _sequenceGenerator.GenerateSequenceFor(5, Arg.Is<ISequenceGeneratorStrategy>(x => x is FizzBuzzSequenceNumberStrategy)).
                                    Returns(new List<string> { "1", "2", "C", "4", "E" });
            _sequenceGenerator.GenerateSequenceFor(5, Arg.Is<ISequenceGeneratorStrategy>(x => x is AllNumbersUptoAGivenNumberStrategy)).
                                    Returns(new List<string> { "1", "2", "3", "4", "5" });

            var result =_sequenceCalculatorService.CalculateSequence(5);

            result.Should().BeEquivalentTo(expectedSequenceNumbers);
        }
    }
}
