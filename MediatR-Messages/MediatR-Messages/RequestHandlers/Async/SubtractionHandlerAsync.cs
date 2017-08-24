using System.Threading.Tasks;
using MediatR;
using MediatRMessages.Request;
using MediatRMessages.Response;

namespace MediatRMessages.RequestHandlers.Async
{
    public class SubtractionHandlerAsync : IAsyncRequestHandler<SubtractionRequest, MathResponse>
    {
        public Task<MathResponse> Handle(SubtractionRequest request)
        {
            Task.Delay(3000); //Wait 3 seconds
            return Task.FromResult(request.Execute());
        }
    }
}
