using Application.Commands.Requests;
using Application.Commands.Responses;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Handlers;

public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
{
    private readonly ILogger _logger;

    private readonly IUserRepository _userRepository;

    public DeleteUserHandler(ILogger<DeleteUserHandler> logger, IUserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    public Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _userRepository.DeleteUser(request.Id);

            return Task.FromResult(new DeleteUserResponse());
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"Internal server error - Error trace: {ex.StackTrace}", DateTime.UtcNow);
            throw;
        }
    }
}

