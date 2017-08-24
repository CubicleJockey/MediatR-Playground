using System;
using FluentAssertions;
using MediatRMessages.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatRMessages.UnitTests.Response
{
    
    public class AdditionResponseTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [DataTestMethod]
            [DataRow(null)]
            [DataRow("")]
            [DataRow("   ")]
            public void EquationParameter_IsInvalid(string equation)
            {
                Action ctor = () => new MathResponse(equation, 0);
                ctor.ShouldThrow<ArgumentException>()
                    .WithMessage($"Cannot be empty.{Environment.NewLine}Parameter name: equation");
            }
        }
    }
}
