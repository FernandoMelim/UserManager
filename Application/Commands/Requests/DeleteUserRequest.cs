using Application.Commands.Responses;
using MediatR;

namespace Application.Commands.Requests;

public class DeleteUserRequest : IRequest<DeleteUserResponse>
{
}

