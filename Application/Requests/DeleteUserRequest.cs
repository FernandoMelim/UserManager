using Application.Responses;
using MediatR;

namespace Application.Requests;

public class DeleteUserRequest : IRequest<DeleteUserResponse>
{
    public int Id { get; set; }
}

