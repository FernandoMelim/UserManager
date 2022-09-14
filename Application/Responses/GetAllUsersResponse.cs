using Domain.Enums;

namespace Application.Responses;

public class GetAllUsersResponse
{
    public IEnumerable<UserModel> UserList { get; set; } = new List<UserModel>();
}

public class UserModel
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string Email { get; set; }

    public DateTime BirthDate { get; set; }

    public SchoolingLevelEnum SchoolingLevel { get; set; }
}

