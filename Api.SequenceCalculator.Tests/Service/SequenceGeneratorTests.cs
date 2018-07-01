using Api.SequenceCalculator.Service;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Api.SequenceCalculator.Tests.Service
{
    [TestFixture]
    public class SequenceGeneratorTests
    {
        private SequenceGenerator _sequenceGenerator;

        [SetUp]
        public void Setup()
        {
            _sequenceGenerator = new SequenceGenerator();
        }

        [Test]
        public void SequenceGenerator_Returns_EvenNumbers_On_Passing_InstanceOf_EvenStrategy_Object()
        {
            var expectedResponse = new List<string>
            {
                 "2", "4"
            };

            var evenStrategyObject = new EvenNumbersUptoAGivenNumberStrategy();
            var result = _sequenceGenerator.GenerateSequenceFor(5, evenStrategyObject);

            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Test]
        public void SequenceGenerator_Returns_OddNumbers_On_Passing_InstanceOf_OddNumberStrategy_Object()
        {
            var expectedResponse = new List<string>
            {
                 "1", "3", "5"
            };

            var oddNumberStrategyObject = new OddNumbersUptoAGivenNumberStrategy();
            var result = _sequenceGenerator.GenerateSequenceFor(5, oddNumberStrategyObject);

            result.Should().BeEquivalentTo(expectedResponse);
        }


        [Test]
        public void SequenceGenerator_Returns_AllNumbers_On_Passing_InstanceOf_AllNumberStrategy_Object()
        {
            var expectedResponse = new List<string>
            {
                "1", "2", "3", "4", "5"
            };

            var allNumberStrategyObject = new AllNumbersUptoAGivenNumberStrategy();
            var result = _sequenceGenerator.GenerateSequenceFor(5, allNumberStrategyObject);

            result.Should().BeEquivalentTo(expectedResponse);
        }


        [Test]
        public void SequenceGenerator_Returns_FizzBuzzSequence_On_Passing_InstanceOf_FizzBuzzSequenceStrategy_Object()
        {
            var expectedResponse = new List<string>
            {
                 "1", "2", "C", "4", "E", "C", "7","8","C", "E", "11","C","13","14","Z","16"
            };

            var fizzBuzzStrategyObject = new FizzBuzzSequenceNumberStrategy();
            var result = _sequenceGenerator.GenerateSequenceFor(16, fizzBuzzStrategyObject);

            result.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
