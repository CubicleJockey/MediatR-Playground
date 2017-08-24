using MediatR;
using MediatRMessages.Request;
using MediatRMessages.Response;

namespace MediatRMessages.RequestHandlers
{
    public class SubtractionHandler : IRequestHandler<SubtractionRequest, MathResponse>
    {
        public MathResponse Handle(SubtractionRequest request)
        {
            return request.Execute();
        }
    }
}
