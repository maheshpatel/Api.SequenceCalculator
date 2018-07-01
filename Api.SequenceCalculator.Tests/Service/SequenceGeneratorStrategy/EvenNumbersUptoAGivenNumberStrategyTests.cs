using System.Collections.Generic;
using Api.SequenceCalculator.Service;
using FluentAssertions;
using NUnit.Framework;

namespace Api.SequenceCalculator.Tests.Service
{

    [TestFixture]
    public class EvenNumbersUptoAGivenNumberStrategyTests
    {
        private EvenNumbersUptoAGivenNumberStrategy evenNumbersSequenceGenerator;

        [SetUp]
        public void Setup()
        {
            evenNumbersSequenceGenerator = new EvenNumbersUptoAGivenNumberStrategy();
        }


        [Test]
        public void EvenNumbersUptoGivenNumberStrategy_Returns_EvenNumbers()
        {
            var expectedResponse = new List<string>
            {
                 "2", "4"
            };

            var result = evenNumbersSequenceGenerator.GenerateSequenceNumbers(5);
            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Test]
        public void EvenNumbersUptoGivenNumberStrategy_Returns_EvenNumbersIncludingGivenInputNumber()
        {
            var expectedResponse = new List<string>
            {
                 "2", "4"
            };

            var result = evenNumbersSequenceGenerator.GenerateSequenceNumbers(4);
            result.Should().BeEquivalentTo(expectedResponse);
            result[expectedResponse.Count - 1].Contains("4");
        }


    }
}
