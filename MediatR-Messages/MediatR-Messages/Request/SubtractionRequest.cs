using MediatR;
using MediatRMessages.Response;

namespace MediatRMessages.Request
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/Subtraction
    /// </summary>
    public class SubtractionRequest : BaseMathRequest, IRequest<MathResponse>
    {
        public SubtractionRequest(int left, int right) : base(left, right) { }

        public override MathResponse Execute()
        {
            var difference = Left - Right;
            return new MathResponse(ToString(), difference);
        }

        public override string ToString()
        {
            return $"{Left} - {Right}";
        }
    }
}
