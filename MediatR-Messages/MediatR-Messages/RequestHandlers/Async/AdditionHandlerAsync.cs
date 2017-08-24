using System.Threading.Tasks;
using MediatR;
using MediatRMessages.Request;
using MediatRMessages.Response;

namespace MediatRMessages.RequestHandlers.Async
{
    public class AdditionHandlerAsync : IAsyncRequestHandler<AdditionRequest, MathResponse>
    {
        public Task<MathResponse> Handle(AdditionRequest request)
        {
            Task.Delay(3000); //Wait 3 seconds
            return Task.FromResult(request.Execute());
        }
    }
}
