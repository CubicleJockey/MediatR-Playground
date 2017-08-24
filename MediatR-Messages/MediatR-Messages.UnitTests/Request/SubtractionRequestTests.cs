using FluentAssertions;
using MediatR;
using MediatRMessages.Request;
using MediatRMessages.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatRMessages.UnitTests.Request
{
    public class SubtractionRequestTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritance()
            {
                var request = new SubtractionRequest(1, 1);

                request.Should().NotBeNull();
                request.Should().BeAssignableTo<IRequest<MathResponse>>();
                request.Should().BeAssignableTo<BaseMathRequest>();
                request.Should().BeOfType<SubtractionRequest>();
            }
        }

        [TestClass]
        public class MethodTests
        {
            [DataTestMethod]
            [DataRow(1, 1, "1 - 1")]
            [DataRow(1, 3, "1 - 3")]
            [DataRow(2, 16, "2 - 16")]
            [DataRow(0, 42, "0 - 42")]
            [DataRow(-1, -2, "-1 - -2")]
            public void ToString(int left, int right, string result)
            {
                var request = new SubtractionRequest(left, right);

                request.Should().NotBeNull();
                request.ToString().Should().BeEquivalentTo(result);
            }

            [DataTestMethod]
            [DataRow(1, 1, "1 - 1", 0)]
            [DataRow(1, 3, "1 - 3", -2)]
            [DataRow(2, 16, "2 - 16", -14)]
            [DataRow(0, 42, "0 - 42", -42)]
            [DataRow(-1, -2, "-1 - -2", 1)]
            public void Execute(int left, int right, string equation, int answer)
            {
                var request = new SubtractionRequest(left, right);

                request.Should().NotBeNull();

                var response = request.Execute();

                response.Should().NotBeNull();
                response.Equation.Should().BeEquivalentTo(equation);
                response.Answer.ShouldBeEquivalentTo(answer);
            }
        }
    }
}
