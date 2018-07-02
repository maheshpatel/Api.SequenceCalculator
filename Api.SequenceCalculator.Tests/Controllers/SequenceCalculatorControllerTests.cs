using Api.SequenceCalculator.Controllers;
using Api.SequenceCalculator.Models;
using Api.SequenceCalculator.Service;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace Api.SequenceCalculator.Tests.Controllers
{
    [TestFixture]
    public class SequenceCalculatorControllerTests
    {
        private ISequenceCalculatorService sequenceCalculatorService;
        private SequenceCalculatorController sequenceCalculatorController;

        [SetUp]
        public void Setup()
        {
            sequenceCalculatorService = Substitute.For<ISequenceCalculatorService>();
        }

        [Test]
        public void WhenPositiveNumberIsPassed_It_Gives_Sequence_Of_Numbers()
        {
            var expectedSequenceNumbers = new SequenceNumbers()
            {
                AllNumbersUptoGivenNumber = new List<string> { "1", "2", "3", "4", "5" },
                EvenNumbersUptoGivenNumber = new List<string> { "2", "4" },
                OddNumbersUptoGivenNumber = new List<string> { "1", "3", "5" },
                FizzBuzzSequenceNumbersUptoGivenNumber = new List<string> { "1", "2", "C", "4", "E" }
            };

            sequenceCalculatorService.CalculateSequence(5).Returns(expectedSequenceNumbers);

            sequenceCalculatorController = new SequenceCalculatorController(sequenceCalculatorService);
            var result = sequenceCalculatorController.CalculateSequence(5) as OkNegotiatedContentResult<SequenceNumbers>;

            result?.Content.Should().BeEquivalentTo(expectedSequenceNumbers);
        }

        [Test]
        public void WhenNegativeValueEntered_Controller_Returns_BadRequestError()
        {
            sequenceCalculatorController = new SequenceCalculatorController(sequenceCalculatorService);

            var result = sequenceCalculatorController.CalculateSequence(-1);
            result?.Should().BeOfType(typeof(BadRequestResult));
        }
    }
}
