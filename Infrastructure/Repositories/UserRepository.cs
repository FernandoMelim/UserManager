using Domain.Models;
using Infrastructure.AppContextConfiguration;
using Infrastructure.Exceptions;
using System.Data;

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
        var dbUser = _db.Users.FirstOrDefault(x => x.Id == user.Id);

        if (dbUser == null)
            throw new ObjectNotFoundException();

        dbUser.Name = user.Name;
        dbUser.Surname = user.Surname;
        dbUser.BirthDate = user.BirthDate;
        dbUser.SchoolingLevel = user.SchoolingLevel;
        dbUser.Email = user.Email;

        _db.SaveChanges();

        return dbUser;
    }

    public void DeleteUser(int id)
    {
        var user = _db.Users.FirstOrDefault(x => x.Id == id);

        if (user == null)
            throw new ObjectNotFoundException();

        _db.Users.Remove(user);

        _db.SaveChanges();
    }

    public User GetUser(int id)
    {
        var user = _db.Users.FirstOrDefault(x => x.Id == id);

        if (user == null)
            throw new ObjectNotFoundException();

        return user;
    }
}

