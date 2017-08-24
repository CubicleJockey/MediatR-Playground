using MediatR;
using MediatRMessages.Request;
using MediatRMessages.Response;

namespace MediatRMessages.RequestHandlers
{
    public class DivisionHandler : IRequestHandler<DivisionRequest, MathResponse>
    {
        public MathResponse Handle(DivisionRequest request)
        {
            return request.Execute();
        }
    }
}
