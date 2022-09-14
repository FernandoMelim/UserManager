using Domain.Models;

namespace Infrastructure.Repositories;

public interface IUserRepository
{
    User CreateUser(User user);

    User EditUser(User user);

    void DeleteUser(int id);

    User GetUser(int id);
}

