using FluentAssertions;
using MediatR;
using MediatRMessages.Request;
using MediatRMessages.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatRMessages.UnitTests.Request
{
    public class AdditionRequestTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritance()
            {
                var request = new AdditionRequest(1, 1);

                request.Should().NotBeNull();
                request.Should().BeAssignableTo<IRequest<AdditionResponse>>();
                request.Should().BeOfType<AdditionRequest>();
            }
        }

        [TestClass]
        public class MethodTests
        {
            [DataTestMethod]
            [DataRow(1, 1, "1 + 1")]
            [DataRow(1, 3, "1 + 3")]
            [DataRow(2, 16, "2 + 16")]
            [DataRow(0, 42, "0 + 42")]
            [DataRow(-1, -2, "-1 + -2")]
            public void ToString(int left, int right, string result)
            {
                var request = new AdditionRequest(left, right);

                request.Should().NotBeNull();
                request.ToString().Should().BeEquivalentTo(result);
            }

            [DataTestMethod]
            [DataRow(1, 1, "1 + 1", 2)]
            [DataRow(1, 3, "1 + 3", 4)]
            [DataRow(2, 16, "2 + 16", 18)]
            [DataRow(0, 42, "0 + 42", 42)]
            [DataRow(-1, -2, "-1 + -2", -3)]
            public void Execute(int left, int right, string equation, int answer)
            {
                var request = new AdditionRequest(left, right);

                request.Should().NotBeNull();

                var response = request.Execute();

                response.Should().NotBeNull();
                response.Equation.Should().BeEquivalentTo(equation);
                response.Answer.ShouldBeEquivalentTo(answer);

            }
        }
    }
}
