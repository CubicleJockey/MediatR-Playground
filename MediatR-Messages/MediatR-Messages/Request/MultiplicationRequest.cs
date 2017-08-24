using MediatR;
using MediatRMessages.Response;

namespace MediatRMessages.Request
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/Multiplication
    /// </summary>
    public class MultiplicationRequest : BaseMathRequest, IRequest<MathResponse>
    {
        public MultiplicationRequest(int left, int right) : base(left, right) { }

        public override MathResponse Execute()
        {
            var answer = Left * Right;
            return new MathResponse(ToString(), answer);
        }

        public override string ToString()
        {
            return $"{Left} * {Right}";
        }
    }
}
