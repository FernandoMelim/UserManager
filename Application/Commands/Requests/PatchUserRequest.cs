using Domain.Enums;

namespace Domain.Commands.Requests;

public class PatchUserRequest
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string Email { get; set; }

    public DateTime BirthDate { get; set; }

    public SchoolingLevelEnum SchoolingLevel { get; set; }
}

