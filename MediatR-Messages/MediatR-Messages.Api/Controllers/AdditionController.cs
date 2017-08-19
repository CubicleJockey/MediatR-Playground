using System.Threading.Tasks;
using MediatR;
using MediatRMessages.Request;
using MediatRMessages.Response;
using Microsoft.AspNetCore.Mvc;

namespace MediatRMessages.Api.Controllers
{
    [Route("api/[controller]")]
    public class AdditionController : Controller
    {
        private readonly IMediator mediator;

        public AdditionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET api/values
        [HttpGet]
        public Task<AdditionResponse> Get(int left, int right)
        {
            return mediator.Send(new AdditionRequest(left, right));
        }
    }
}
