using System.Threading.Tasks;
using MediatR;
using MediatRMessages.Request;
using MediatRMessages.Response;

namespace MediatRMessages.RequestHandlers.Async
{
    public class DivisionHandlerAsync : IAsyncRequestHandler<DivisionRequest, MathResponse>
    {
        public Task<MathResponse> Handle(DivisionRequest request)
        {
            Task.Delay(3000); //Wait 3 seconds
            return Task.FromResult(request.Execute());
        }
    }
}
