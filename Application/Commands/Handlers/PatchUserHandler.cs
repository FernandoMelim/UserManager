using Application.Commands.Requests;
using Application.Commands.Responses;
using MediatR;

namespace Application.Commands.Handlers;

public class PatchUserHandler : IRequestHandler<PatchUserRequest, PatchUserResponse>
{
    public Task<PatchUserResponse> Handle(PatchUserRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new PatchUserResponse());
        throw new NotImplementedException();
    }
}

