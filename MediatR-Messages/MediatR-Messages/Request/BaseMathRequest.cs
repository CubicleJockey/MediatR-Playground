using MediatRMessages.Response;

namespace MediatRMessages.Request
{
    public abstract class BaseMathRequest
    {
        protected int Left { get; }
        protected int Right { get; }

        protected BaseMathRequest(int dividend, int divisor)
        {
            Left = dividend;
            Right = divisor;
        }

        public abstract MathResponse Execute();
        public new abstract string ToString();
    }
}
