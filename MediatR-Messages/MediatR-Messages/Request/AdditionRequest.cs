using MediatR;
using MediatRMessages.Response;

namespace MediatRMessages.Request
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/Addition
    /// </summary>
    public class AdditionRequest : BaseMathRequest, IRequest<MathResponse>
    {
        public AdditionRequest(int dividend, int divisor) : base(dividend, divisor) { }

        public override MathResponse Execute()
        {
            var answer = Left + Right;
            return new MathResponse(ToString(), answer);
        }

        public override string ToString()
        {
            return $"{Left} + {Right}";
        }
    }
}
