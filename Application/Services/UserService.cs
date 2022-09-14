using Application.Commands.Requests;
using Domain.Models;
using Infrastructure.AppContextConfiguration;
using Infrastructure.Repositories;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


}

