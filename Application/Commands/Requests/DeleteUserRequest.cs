using Application.Commands.Responses;
using MediatR;

namespace Application.Commands.Requests;

public class DeleteUserRequest : IRequest<DeleteUserResponse>
{
    public int Id { get; set; }
}

