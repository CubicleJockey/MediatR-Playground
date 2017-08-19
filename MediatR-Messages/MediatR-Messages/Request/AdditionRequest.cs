using MediatR;
using MediatRMessages.Response;

namespace MediatRMessages.Request
{
    public class AdditionRequest : IRequest<AdditionResponse>
    {
        public int Left { get; }
        public int Right { get; }

        public AdditionRequest(int left, int right)
        {
            Left = left;
            Right = right;
        }

        public AdditionResponse Execute()
        {
            var answer = Left + Right;
            return new AdditionResponse(ToString(), answer);
        }

        public override string ToString()
        {
            return $"{Left} + {Right}";
        }
    }
}
