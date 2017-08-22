﻿using System.Threading.Tasks;
using MediatR;
using MediatRMessages.Request;
using MediatRMessages.Response;

namespace MediatRMessages.RequestHandlers
{
    public class AdditionHandlerAsync : IAsyncRequestHandler<AdditionRequest, AdditionResponse>
    {
        public Task<AdditionResponse> Handle(AdditionRequest request)
        {
            Task.Delay(3000); //Wait 3 seconds
            return Task.FromResult(request.Execute());
        }
    }
}