using Application.Commands.Requests;
using Application.Commands.Responses;
using MediatR;

namespace Application.Commands.Handlers;

public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
{
    public Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {

        return Task.FromResult(new DeleteUserResponse());
        throw new NotImplementedException();
    }
}

