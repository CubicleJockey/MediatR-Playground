using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using MediatR;
using MediatRMessages.Request;
using MediatRMessages.RequestHandlers;
using MediatRMessages.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatRMessages.UnitTests.RequestHandlers
{
    public class MultiplicationHandlerTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritance()
            {
                var handler = new MultiplicationHandler();

                handler.Should().NotBeNull();
                handler.Should().BeAssignableTo<IRequestHandler<MultiplicationRequest, MathResponse>>();
                handler.Should().BeOfType<MultiplicationHandler>();
            }
        }

        [TestClass]
        public class MethodTests
        {
            [TestMethod]
            public void Valid()
            {
                const int LEFT = 4;
                const int RIGHT = 4;

                var request = new MultiplicationRequest(LEFT, RIGHT);

                request.Should().NotBeNull();

                var handler = new MultiplicationHandler();

                handler.Should().NotBeNull();

                var response = handler.Handle(request);

                response.Should().NotBeNull();
                response.Equation.Should().BeEquivalentTo($"{LEFT} * {RIGHT}");
                response.Answer.ShouldBeEquivalentTo(16);
            }
        }
    }
}
