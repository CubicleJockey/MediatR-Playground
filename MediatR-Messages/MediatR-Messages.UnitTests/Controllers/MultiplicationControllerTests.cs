using System;
using FakeItEasy;
using FluentAssertions;
using MediatR;
using MediatRMessages.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatRMessages.UnitTests.Controllers
{
    public class MultiplicationControllerTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private IMediator fakeMediator;

            [TestInitialize]
            public void TestInitialize()
            {
                fakeMediator = A.Fake<IMediator>();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeMediator);
            }

            [TestMethod]
            public void IsValid()
            {
                var controller = new MultiplicationController(fakeMediator);

                controller.Should().NotBeNull();
                controller.Should().BeAssignableTo<Controller>();
                controller.Should().BeOfType<MultiplicationController>();
            }

            [TestMethod]
            public void NullMediator()
            {
                Action ctor = () => new MultiplicationController(null);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: mediator");
            }
        }
    }
}
