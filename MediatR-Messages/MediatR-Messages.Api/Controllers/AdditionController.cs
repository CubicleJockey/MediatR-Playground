using System.Threading.Tasks;
using MediatR;
using MediatRMessages.Request;
using MediatRMessages.Response;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MediatRMessages.Api.Controllers
{
    /// <summary>
    /// Addition Controller
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AdditionController : Controller
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Addition Controller Ctor
        /// </summary>
        /// <param name="mediator"></param>
        public AdditionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get Methods that takes two numbers and gets the sum.
        /// </summary>
        /// <param name="left">Left hand side of the equation.</param>
        /// <param name="right">Right hand side of the equation.</param>
        /// <returns>Addition Response, which includes the SUM and other information.</returns>
        // GET api/values
        [HttpGet]
        [Produces(typeof(Task<MathResponse>))]
        [SwaggerResponse(200, Type = typeof(Task<MathResponse>))]
        public Task<MathResponse> Get(int left, int right)
        {
            return mediator.Send(new AdditionRequest(left, right));
        }
    }
}
