using MediatR;
using MediatRMessages.Request;
using MediatRMessages.Response;

namespace MediatRMessages.RequestHandlers
{
    public class AdditionHandler : IRequestHandler<AdditionRequest, MathResponse>
    {
        public MathResponse Handle(AdditionRequest request)
        {
            return request.Execute();
        }
    }
}
