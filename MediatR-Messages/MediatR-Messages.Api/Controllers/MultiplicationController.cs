using System.Threading.Tasks;
using MediatR;
using MediatRMessages.Request;
using MediatRMessages.Response;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MediatRMessages.Api.Controllers
{
    /// <summary>
    /// Multiplication Controller
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MultiplicationController : Controller
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Multiplication Controller Ctor
        /// </summary>
        /// <param name="mediator"></param>
        public MultiplicationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get Methods that takes two numbers and multiple them.
        /// </summary>
        /// <param name="left">Left hand side of the equation.</param>
        /// <param name="right">Right hand side of the equation.</param>
        /// <returns>Math Response, which includes the PRODUCT and other information.</returns>
        [HttpGet]
        [Produces(typeof(Task<MathResponse>))]
        [SwaggerResponse(200, Type = typeof(Task<MathResponse>))]
        public Task<MathResponse> Get(int left, int right)
        {
            return mediator.Send(new MultiplicationRequest(left, right));
        }
    }
}
