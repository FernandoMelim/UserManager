using Application.Commands.Responses;
using Domain.Enums;
using MediatR;

namespace Application.Commands.Requests;

public class PostUserRequest : IRequest<PostUserResponse>
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public string Email { get; set; }

    public DateTime BirthDate { get; set; }

    public SchoolingLevelEnum SchoolingLevel { get; set; }
}

