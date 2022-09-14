using Application.Responses;
using MediatR;

namespace Application.Requests;

public class GetUserRequest : IRequest<GetUserResponse>
{
    public int Id { get; set; }
}

