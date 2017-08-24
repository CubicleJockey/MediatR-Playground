using System;
using System.Threading.Tasks;
using MediatR;
using MediatRMessages.Request;
using MediatRMessages.Response;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MediatRMessages.Api.Controllers
{
    /// <summary>
    /// Division Controller
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DivisionController : Controller
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Addition Controller Ctor
        /// </summary>
        /// <param name="mediator"></param>
        public DivisionController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Get Methods that takes two numbers and division them.
        /// </summary>
        /// <param name="dividend">Left hand side of the equation.</param>
        /// <param name="divisor">Right hand side of the equation.</param>
        /// <returns>Math Response, which includes the quotient and other information.</returns>
        [HttpGet]
        [Produces(typeof(Task<MathResponse>))]
        [SwaggerResponse(200, Type = typeof(Task<MathResponse>))]
        public Task<MathResponse> Get(int dividend, int divisor)
        {
            return mediator.Send(new DivisionRequest(dividend, divisor));
        }
    }
}
