using System.Collections.Generic;
using Api.SequenceCalculator.Service;
using FluentAssertions;
using NUnit.Framework;

namespace Api.SequenceCalculator.Tests.Service
{
    [TestFixture]
    public class OddNumbersUptoAGivenNumberStrategyTests
    {
        private OddNumbersUptoAGivenNumberStrategy oddNumbersSequenceGenerator;

        [SetUp]
        public void Setup()
        {
            oddNumbersSequenceGenerator = new OddNumbersUptoAGivenNumberStrategy();
        }

        [Test]
        public void OddNumbersUptoAGivenNumberStrategy_Returns_OddNumbers()
        {
            var expectedResponse = new List<string>
            {
                 "1", "3", "5"
            };

            var result = oddNumbersSequenceGenerator.GenerateSequenceNumbers(5);
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Test]
        public void OddNumbersUptoAGivenNumberStrategy_Returns_OddNumbersIncludingGivenInputNumber()
        {
            var expectedResponse = new List<string>
            {
                 "1", "3", "5"
            };

            var result = oddNumbersSequenceGenerator.GenerateSequenceNumbers(5);
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedResponse);
            result[expectedResponse.Count - 1].Contains("5");
        }

    }
}
