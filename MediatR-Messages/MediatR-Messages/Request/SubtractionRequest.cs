﻿using MediatR;
using MediatRMessages.Response;

namespace MediatRMessages.Request
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/Subtraction
    /// </summary>
    public class SubtractionRequest : BaseMathRequest, IRequest<MathResponse>
    {
        public SubtractionRequest(int dividend, int divisor) : base(dividend, divisor) { }

        public override MathResponse Execute()
        {
            var answer = Left - Right;
            return new MathResponse(ToString(), answer);
        }

        public override string ToString()
        {
            return $"{Left} - {Right}";
        }
    }
}
