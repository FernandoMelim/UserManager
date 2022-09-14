using Application.Commands.Requests;
using Application.Commands.Responses;
using AutoMapper;
using Domain.Models;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Handlers;

public class PatchUserHandler : IRequestHandler<PatchUserRequest, PatchUserResponse>
{
    private readonly ILogger _logger;

    private readonly IUserRepository _userRepository;

    private readonly IMapper _mapper;

    public PatchUserHandler(ILogger<PatchUserHandler> logger, IUserRepository userRepository, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public Task<PatchUserResponse> Handle(PatchUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var newUser = _mapper.Map<User>(request);

            var createdUser = _mapper.Map<PatchUserResponse>(_userRepository.EditUser(newUser));

            return Task.FromResult(createdUser);
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"Internal server error - Error trace: {ex.StackTrace}", DateTime.UtcNow);
            throw ex;
        }
    }
}

