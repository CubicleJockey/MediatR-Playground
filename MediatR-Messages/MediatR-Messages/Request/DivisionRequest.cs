using System;
using MediatR;
using MediatRMessages.Response;

namespace MediatRMessages.Request
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/Division_(mathematics)
    /// </summary>
    public class DivisionRequest : BaseMathRequest, IRequest<MathResponse>
    {
        public DivisionRequest(int dividend, int divisor) : base(dividend, divisor)
        {
            if(divisor == 0) { throw new ArgumentException("Cannot divide by zero.", nameof(divisor));}
        }

        public override MathResponse Execute()
        {
            var quotient = Left / Right;
            return new MathResponse(ToString(), quotient);
        }

        public override string ToString()
        {
            return $"{Left} / {Right}";
        }
    }
}
