using System;
using FluentAssertions;
using MediatR;
using MediatRMessages.Request;
using MediatRMessages.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatRMessages.UnitTests.Request
{
    public class DivisionRequestTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritance()
            {
                var request = new DivisionRequest(1, 1);

                request.Should().NotBeNull();
                request.Should().BeAssignableTo<IRequest<MathResponse>>();
                request.Should().BeAssignableTo<BaseMathRequest>();
                request.Should().BeOfType<DivisionRequest>();
            }

            [TestMethod]
            public void DivisorIsZero()
            {
                Action ctor = () => new DivisionRequest(1, 0);

                ctor.ShouldThrow<ArgumentException>()
                    .WithMessage($"Cannot divide by zero.{Environment.NewLine}Parameter name: divisor");
            }
        }

        [TestClass]
        public class MethodTests
        {
            [DataTestMethod]
            [DataRow(1, 1, "1 / 1")]
            [DataRow(1, 3, "1 / 3")]
            [DataRow(2, 16, "2 / 16")]
            [DataRow(0, 42, "0 / 42")]
            [DataRow(-1, -2, "-1 / -2")]
            public void ToString(int left, int right, string result)
            {
                var request = new DivisionRequest(left, right);

                request.Should().NotBeNull();
                request.ToString().Should().BeEquivalentTo(result);
            }

            [DataTestMethod]
            [DataRow(1, 1, "1 / 1", 1)]
            [DataRow(16, 4, "16 / 4", 4)]
            [DataRow(16, 2, "16 / 2", 8)]
            [DataRow(100, 25, "100 / 25", 4)]
            [DataRow(2, 2, "2 / 2", 1)]
            public void Execute(int left, int right, string equation, int answer)
            {
                var request = new DivisionRequest(left, right);

                request.Should().NotBeNull();

                var response = request.Execute();

                response.Should().NotBeNull();
                response.Equation.Should().BeEquivalentTo(equation);
                response.Answer.ShouldBeEquivalentTo(answer);
            }
        }
    }
}
