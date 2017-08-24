using System.Threading.Tasks;
using FluentAssertions;
using MediatR;
using MediatRMessages.Request;
using MediatRMessages.RequestHandlers.Async;
using MediatRMessages.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatRMessages.UnitTests.RequestHandlers.Async
{
    public class AdditionHandlerAsyncTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritance()
            {
                var handlerAsync = new AdditionHandlerAsync();

                handlerAsync.Should().NotBeNull();
                handlerAsync.Should().BeAssignableTo<IAsyncRequestHandler<AdditionRequest, MathResponse>>();
                handlerAsync.Should().BeOfType<AdditionHandlerAsync>();
            }
        }

        [TestClass]
        public class MethodTests
        {
            [TestMethod]
            public async Task AsyncHandler()
            {
                const int LEFT = 2;
                const int RIGHT = 2;

                var request = new AdditionRequest(LEFT, RIGHT);

                request.Should().NotBeNull();

                var handlerAsync = new AdditionHandlerAsync();

                handlerAsync.Should().NotBeNull();

                var response = await handlerAsync.Handle(request);

                response.Should().NotBeNull();

                response.Equation.Should().BeEquivalentTo($"{LEFT} + {RIGHT}");
                response.Answer.ShouldBeEquivalentTo(4);

            }
        }
    }
}
