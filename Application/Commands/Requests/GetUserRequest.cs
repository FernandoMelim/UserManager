using Application.Commands.Responses;
using MediatR;

namespace Application.Commands.Requests;

public class GetUserRequest : IRequest<GetUserResponse>
{
    public int Id { get; set; }
}

