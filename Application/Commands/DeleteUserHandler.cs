using Application.Requests;
using Application.Responses;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Application.Commands;

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

            var response = new DeleteUserResponse()
            {
                StatusCode = HttpStatusCode.OK,
            };

            return Task.FromResult(response);
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"Internal server error - Error trace: {ex.StackTrace}", DateTime.UtcNow);
            throw;
        }
    }
}

