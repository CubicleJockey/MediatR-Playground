using FluentAssertions;
using MediatR;
using MediatRMessages.Request;
using MediatRMessages.RequestHandlers;
using MediatRMessages.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatRMessages.UnitTests.RequestHandlers
{
    public class SubtractionHandlerTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritance()
            {
                var handler = new SubtractionHandler();

                handler.Should().NotBeNull();
                handler.Should().BeAssignableTo<IRequestHandler<SubtractionRequest, MathResponse>>();
                handler.Should().BeOfType<SubtractionHandler>();
            }
        }

        [TestClass]
        public class MethodTests
        {
            [TestMethod]
            public void Valid()
            {
                const int LEFT = 5;
                const int RIGHT = 1;

                var request = new SubtractionRequest(LEFT, RIGHT);

                request.Should().NotBeNull();

                var handler = new SubtractionHandler();

                handler.Should().NotBeNull();

                var response = handler.Handle(request);

                response.Should().NotBeNull();
                response.Equation.Should().BeEquivalentTo($"{LEFT} - {RIGHT}");
                response.Answer.ShouldBeEquivalentTo(4);
            }
        }
    }
}
