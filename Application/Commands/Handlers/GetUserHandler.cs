using Application.Commands.Requests;
using Application.Commands.Responses;
using MediatR;

public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
{
    public Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new GetUserResponse());
        throw new NotImplementedException();
    }
}

