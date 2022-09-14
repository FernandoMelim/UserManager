using Application.Commands.Requests;
using Application.Commands.Responses;
using AutoMapper;
using Domain.Models;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Handlers;

public class PostUserHandler : IRequestHandler<PostUserRequest, PostUserResponse>
{
    private readonly ILogger _logger;

    private readonly IUserRepository _userRepository;

    private readonly IMapper _mapper;

    public PostUserHandler(ILogger<PostUserHandler> logger, IUserRepository userRepository, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public Task<PostUserResponse> Handle(PostUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var newUser = _mapper.Map<User>(request);

            var createdUser = _mapper.Map<PostUserResponse>(_userRepository.CreateUser(newUser));

            return Task.FromResult(createdUser);
        }
        catch(Exception ex)
        {
            _logger.LogInformation($"Internal server error - Error trace: {ex.StackTrace}", DateTime.UtcNow);
            throw new Exception();
        }
    }
}

