using FluentAssertions;
using MediatR;
using MediatRMessages.Request;
using MediatRMessages.RequestHandlers;
using MediatRMessages.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatRMessages.UnitTests.RequestHandlers
{
    public class AdditionHandlerTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritance()
            {
                var handler =  new AdditionHandler();

                handler.Should().NotBeNull();
                handler.Should().BeAssignableTo<IRequestHandler<AdditionRequest, MathResponse>>();
                handler.Should().BeOfType<AdditionHandler>();
            }
        }

        [TestClass]
        public class MethodTests
        {
            [TestMethod]
            public void Valid()
            {
                const int LEFT = 1;
                const int RIGHT = 4;

                var request = new AdditionRequest(LEFT, RIGHT);

                request.Should().NotBeNull();

                var handler = new AdditionHandler();

                handler.Should().NotBeNull();

                var response = handler.Handle(request);

                response.Should().NotBeNull();
                response.Equation.Should().BeEquivalentTo($"{LEFT} + {RIGHT}");
                response.Answer.ShouldBeEquivalentTo(5);
            }
        }
    }
}
