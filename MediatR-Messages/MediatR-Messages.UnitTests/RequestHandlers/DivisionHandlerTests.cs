﻿using FluentAssertions;
using MediatR;
using MediatRMessages.Request;
using MediatRMessages.RequestHandlers;
using MediatRMessages.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatRMessages.UnitTests.RequestHandlers
{
    public class DivisionHandlerTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritance()
            {
                var handler = new DivisionHandler();

                handler.Should().NotBeNull();
                handler.Should().BeAssignableTo<IRequestHandler<DivisionRequest, MathResponse>>();
                handler.Should().BeOfType<DivisionHandler>();
            }
        }

        [TestClass]
        public class MethodTests
        {
            [TestMethod]
            public void Valid()
            {
                const int LEFT = 16;
                const int RIGHT = 4;

                var request = new DivisionRequest(LEFT, RIGHT);

                request.Should().NotBeNull();

                var handler = new DivisionHandler();

                handler.Should().NotBeNull();

                var response = handler.Handle(request);

                response.Should().NotBeNull();
                response.Equation.Should().BeEquivalentTo($"{LEFT} / {RIGHT}");
                response.Answer.ShouldBeEquivalentTo(4);
            }
        }
    }
}
