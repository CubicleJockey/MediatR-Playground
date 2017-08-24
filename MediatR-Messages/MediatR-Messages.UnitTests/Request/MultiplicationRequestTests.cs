using FluentAssertions;
using MediatR;
using MediatRMessages.Request;
using MediatRMessages.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatRMessages.UnitTests.Request
{
    public class MultiplicationRequestTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritance()
            {
                var request = new MultiplicationRequest(1, 1);

                request.Should().NotBeNull();
                request.Should().BeAssignableTo<IRequest<MathResponse>>();
                request.Should().BeAssignableTo<BaseMathRequest>();
                request.Should().BeOfType<MultiplicationRequest>();
            }
        }

        [TestClass]
        public class MethodTests
        {
            [DataTestMethod]
            [DataRow(1, 1, "1 * 1")]
            [DataRow(1, 3, "1 * 3")]
            [DataRow(2, 16, "2 * 16")]
            [DataRow(0, 42, "0 * 42")]
            [DataRow(-1, -2, "-1 * -2")]
            public void ToString(int left, int right, string result)
            {
                var request = new MultiplicationRequest(left, right);

                request.Should().NotBeNull();
                request.ToString().Should().BeEquivalentTo(result);
            }

            [DataTestMethod]
            [DataRow(1, 1, "1 * 1", 1)]
            [DataRow(1, 3, "1 * 3", 3)]
            [DataRow(2, 16, "2 * 16", 32)]
            [DataRow(0, 42, "0 * 42", 0)]
            [DataRow(-1, -2, "-1 * -2", 2)]
            public void Execute(int left, int right, string equation, int answer)
            {
                var request = new MultiplicationRequest(left, right);

                request.Should().NotBeNull();

                var response = request.Execute();

                response.Should().NotBeNull();
                response.Equation.Should().BeEquivalentTo(equation);
                response.Answer.ShouldBeEquivalentTo(answer);
            }
        }
    }
}
