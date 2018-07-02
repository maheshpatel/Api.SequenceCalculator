using Api.SequenceCalculator.Service;
using Autofac;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Api.SequenceCalculator.Tests.Service
{
    [TestFixture]
    public class SequenceGeneratorTests
    {
        private SequenceGenerator _sequenceGenerator;
        private ILifetimeScope _lifetimeScope;

        public ILifetimeScope TestContainer { get; private set; }

        [SetUp]
        public void Setup()
        {
            _lifetimeScope = ContainerTest.InitialisedContainer;  
            _sequenceGenerator = new SequenceGenerator(_lifetimeScope);
        }

        [Test]
        public void SequenceGenerator_Returns_EvenNumbers_On_Passing_InstanceOf_EvenStrategy_Object()
        {
            var expectedResponse = new List<string>
            {
                 "2", "4"
            };

            var result = _sequenceGenerator.GenerateSequenceFor(5, SequenceType.EvenNumbers);

            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Test]
        public void SequenceGenerator_Returns_OddNumbers_On_Passing_InstanceOf_OddNumberStrategy_Object()
        {
            var expectedResponse = new List<string>
            {
                 "1", "3", "5"
            };

            var result = _sequenceGenerator.GenerateSequenceFor(5, SequenceType.OddNumbers);

            result.Should().BeEquivalentTo(expectedResponse);
        }


        [Test]
        public void SequenceGenerator_Returns_AllNumbers_On_Passing_InstanceOf_AllNumberStrategy_Object()
        {
            var expectedResponse = new List<string>
            {
                "1", "2", "3", "4", "5"
            };

            var result = _sequenceGenerator.GenerateSequenceFor(5, SequenceType.AllNumbers);

            result.Should().BeEquivalentTo(expectedResponse);
        }


        [Test]
        public void SequenceGenerator_Returns_FizzBuzzSequence_On_Passing_InstanceOf_FizzBuzzSequenceStrategy_Object()
        {
            var expectedResponse = new List<string>
            {
                 "1", "2", "C", "4", "E", "C", "7","8","C", "E", "11","C","13","14","Z","16"
            };

            var result = _sequenceGenerator.GenerateSequenceFor(16, SequenceType.FizzBuzzNumbers);

            result.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
