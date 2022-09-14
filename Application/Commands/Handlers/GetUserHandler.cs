using Application.Commands.Requests;
using Application.Commands.Responses;
using AutoMapper;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
{
    private readonly ILogger _logger;

    private readonly IUserRepository _userRepository;

    private readonly IMapper _mapper;

    public GetUserHandler(ILogger<GetUserHandler> logger, IUserRepository userRepository, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var user = _mapper.Map<GetUserResponse>(_userRepository.GetUser(request.Id));

            return Task.FromResult(user);
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"Internal server error - Error trace: {ex.StackTrace}", DateTime.UtcNow);
            throw;
        }
    }
}

