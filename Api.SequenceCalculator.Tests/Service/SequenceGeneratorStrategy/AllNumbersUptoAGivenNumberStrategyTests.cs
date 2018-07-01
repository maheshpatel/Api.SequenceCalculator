using System.Collections.Generic;
using Api.SequenceCalculator.Service;
using FluentAssertions;
using NUnit.Framework;

namespace Api.SequenceCalculator.Tests.Service
{
    [TestFixture]
    public class AllNumbersUptoAGivenNumberStrategyTests
    {
        private AllNumbersUptoAGivenNumberStrategy allNumbersSequenceGenerator;

        [SetUp]
        public void Setup()
        {
            allNumbersSequenceGenerator = new AllNumbersUptoAGivenNumberStrategy();
        }


        [Test]
        public void AllNumbersUptoGivenNumberStrategy_Returns_AllNumbersUptoAGivenNumber()
        {
            var expectedResponse = new List<string>
            {
                "1", "2", "3", "4", "5"
            };

            var result = allNumbersSequenceGenerator.GenerateSequenceNumbers(5);
            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Test]
        public void AllNumbersUptoGivenNumberStrategy_Returns_AllNumbersIncludingGivenInput()
        {
            var expectedResponse = new List<string>
            {
                "1", "2", "3", "4", "5"
            };

            var result = allNumbersSequenceGenerator.GenerateSequenceNumbers(5);
            result.Should().NotBeNull();
            result[expectedResponse.Count - 1].Contains("5");
        }

    }
}
