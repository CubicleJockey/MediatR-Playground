using MediatRMessages.Response;

namespace MediatRMessages.Request
{
    public abstract class BaseMathRequest
    {
        protected int Left { get; }
        protected int Right { get; }

        protected BaseMathRequest(int left, int right)
        {
            Left = left;
            Right = right;
        }

        public abstract MathResponse Execute();
        public new abstract string ToString();
    }
}
