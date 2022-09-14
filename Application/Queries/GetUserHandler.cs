using Application.Requests;
using Application.Responses;
using AutoMapper;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Application.Queries;

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
            var response = _mapper.Map<GetUserResponse>(_userRepository.GetUser(request.Id));

            response.StatusCode = (int)HttpStatusCode.OK;

            return Task.FromResult(response);
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"Internal server error - Error trace: {ex.StackTrace}", DateTime.UtcNow);
            throw;
        }
    }
}

