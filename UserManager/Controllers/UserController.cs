using Application.Requests;
using Application.Responses;
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

        [HttpGet("{id}")]
        public Task<GetUserResponse> Get([FromRoute] int id)
        {
            return _mediator.Send(new GetUserRequest() { Id = id });
        }

        [HttpGet]
        public Task<GetAllUsersResponse> Get()
        {
            return _mediator.Send(new GetAllUsersRequest());
        }

        [HttpPost]
        public Task<PostUserResponse> Post([FromBody] PostUserRequest postUserRequest)
        {
            return _mediator.Send<PostUserResponse>(postUserRequest);
        }

        [HttpDelete("{id}")]
        public Task<DeleteUserResponse> Delete([FromRoute] int id)
        {
            return _mediator.Send(new DeleteUserRequest() { Id = id });
        }

        [HttpPatch]
        public Task<PatchUserResponse> Patch([FromBody] PatchUserRequest patchUserRequest)
        {
            return _mediator.Send(patchUserRequest);
        }
    }
}