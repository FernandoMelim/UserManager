using Domain.Enums;
using Infrastructure;

namespace Application.Responses;

public class PostUserResponse : ApiResponse
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string Email { get; set; }

    public DateTime BirthDate { get; set; }

    public SchoolingLevelEnum SchoolingLevel { get; set; }
}

