﻿using Application.Commands.Requests;
using Application.Commands.Responses;
using AutoMapper;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Handlers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, GetAllUsersResponse>
{
    private readonly ILogger _logger;

    private readonly IUserRepository _userRepository;

    private readonly IMapper _mapper;

    public GetAllUsersHandler(ILogger<GetAllUsersHandler> logger, IUserRepository userRepository, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public Task<GetAllUsersResponse> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var userList = _userRepository.GetAllUsers().ToList();

            var response = new GetAllUsersResponse();

            userList.ForEach(userEntity =>
            {
                var userModel = _mapper.Map<UserModel>(userEntity);
                response.UserList = response.UserList.Append(userModel);
            });

            return Task.FromResult(response);
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"Internal server error - Error trace: {ex.StackTrace}", DateTime.UtcNow);
            throw;
        }
    }
}

