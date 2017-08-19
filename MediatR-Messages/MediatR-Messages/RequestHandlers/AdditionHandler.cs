using MediatR;
using MediatRMessages.Request;
using MediatRMessages.Response;

namespace MediatRMessages.RequestHandlers
{
    public class AdditionHandler : IRequestHandler<AdditionRequest, AdditionResponse>
    {
        public AdditionResponse Handle(AdditionRequest request)
        {
            return request.Execute();
        }
    }
}
