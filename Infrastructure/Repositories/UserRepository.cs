using Domain.Models;
using Infrastructure.AppContextConfiguration;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationContext _db;
    public UserRepository(ApplicationContext db)
    {
        _db = db;
    }

    public User CreateUser(User user)
    {
        var a = _db.Users.Add(user);
        _db.SaveChanges();

        return user;
    }

    public User EditUser(User user)
    {
        var dbUser = _db.Users.First(x => x.Id == user.Id);

        dbUser.Name = user.Name;
        dbUser.Surname = user.Surname;
        dbUser.BirthDate = user.BirthDate;
        dbUser.SchoolingLevel = user.SchoolingLevel;
        dbUser.Email = user.Email;

        _db.SaveChanges();

        return dbUser;
    }
}

