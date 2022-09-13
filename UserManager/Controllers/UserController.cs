using Application.Commands.Requests;
using Application.Commands.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UserManager.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/{id}")]
        public Task<GetUserResponse> Get([FromRoute] int id)
        {
            return _mediator.Send(new GetUserRequest() { Id = id });
        }

        [HttpGet]
        public Task<GetAllUsersResponse> GetAll()
        {
            return _mediator.Send(new GetAllUsersRequest());
        }

        [HttpPost]
        public Task<PostUserResponse> Post()
        {
            return _mediator.Send(new PostUserRequest());
        }

        [HttpDelete]
        public Task<DeleteUserResponse> Delete()
        {
            return _mediator.Send(new DeleteUserRequest());
        }

        [HttpPatch]
        public Task<PatchUserResponse> Patch()
        {
            return _mediator.Send(new PatchUserRequest());
        }
    }
}