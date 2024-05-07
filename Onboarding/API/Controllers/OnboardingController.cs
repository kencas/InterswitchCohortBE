using Application.Commands;
using Application.Commands.Users;
using Application.Presentation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace API.Controllers
{
    [ApiController]
    [Route("user")]
    public class OnboardingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OnboardingController(IMediator mediator)
        {
            _mediator = mediator;
           
        }

        [HttpPost("create-user")]
        public async Task<ActionResult> Create(CreateUserCommand request,
            CancellationToken cancellationToken)
        {

            try
            {
                var response = await _mediator.Send(request, cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //[HttpPost("get-all-setups")]
        // public async Task<ActionResult<IEnumerable<SetupResponse>>> GetAllSetups([FromQuery] GetSetupQuery query)
        //{
            
        

        //    try
        //    {
        //        var response = await _mediator.Send(query);
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}


        [HttpPost("login")]
        public async Task<ActionResult<BaseResponse<AuthorizationResponse>>> Login(LoginCommand request,
            CancellationToken cancellationToken)
        {

            try
            {
                var response = await _mediator.Send(request, cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}