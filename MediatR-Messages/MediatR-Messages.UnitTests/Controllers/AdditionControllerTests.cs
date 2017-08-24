using System;
using FakeItEasy;
using FluentAssertions;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediatRMessages.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MediatRMessages.UnitTests.Controllers
{
    public class AdditionControllerTests
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
                var controller = new AdditionController(fakeMediator);

                controller.Should().NotBeNull();
                controller.Should().BeAssignableTo<Controller>();
                controller.Should().BeOfType<AdditionController>();
            }

            [TestMethod]
            public void NullMediator()
            {
                Action ctor = () => new AdditionController(null);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: mediator");
            }
        }
    }
}
