using Application.Commands.Requests;
using Application.Commands.Responses;
using MediatR;

namespace Application.Commands.Handlers;

public class PostUserHandler : IRequestHandler<PostUserRequest, PostUserResponse>
{
    public Task<PostUserResponse> Handle(PostUserRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new PostUserResponse());
        throw new NotImplementedException();
    }
}

