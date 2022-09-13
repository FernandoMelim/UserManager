using Application.Commands.Requests;
using Application.Commands.Responses;
using MediatR;

namespace Application.Commands.Handlers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, GetAllUsersResponse>
{
    public Task<GetAllUsersResponse> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new GetAllUsersResponse());
        throw new NotImplementedException();
    }
}

