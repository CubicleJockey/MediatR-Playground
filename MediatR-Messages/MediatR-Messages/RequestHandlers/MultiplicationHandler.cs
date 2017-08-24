using MediatR;
using MediatRMessages.Request;
using MediatRMessages.Response;

namespace MediatRMessages.RequestHandlers
{
    public class MultiplicationHandler : IRequestHandler<MultiplicationRequest, MathResponse>
    {
        public MathResponse Handle(MultiplicationRequest request)
        {
            return request.Execute();
        }
    }
}
