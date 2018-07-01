using Api.SequenceCalculator.Service;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Api.SequenceCalculator.Tests.Service
{
    [TestFixture]
    public class FizzBuzzSequenceNumberStrategyTests
    {
        private FizzBuzzSequenceNumberStrategy fizzBuzzSequenceNumberStrategy;

        [SetUp]
        public void Setup()
        {
            fizzBuzzSequenceNumberStrategy = new FizzBuzzSequenceNumberStrategy();
        }


        [Test]
        public void FizzBuzzSequenceNumberStrategy_Returns_A_FizzBuzzSequence()
        {
            var expectedResponse = new List<string>
            {
                 "1", "2", "C", "4", "E", "C", "7","8","C", "E", "11","C","13","14","Z","16"
            };

            var result = fizzBuzzSequenceNumberStrategy.GenerateSequenceNumbers(16);
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Test]
        public void FizzBuzzSequenceNumberStrategy_Returns_NumbersInclusiveofInputNumber()
        {
            var expectedResponse = new List<string>
            {
                 "1", "2", "C", "4", "E", "C", "7","8","C", "E", "11","C","13","14","Z","16"
            };

            var result = fizzBuzzSequenceNumberStrategy.GenerateSequenceNumbers(16);
            result.Should().BeEquivalentTo(expectedResponse);
            result[expectedResponse.Count - 1].Contains("16");
        }


    }
}
