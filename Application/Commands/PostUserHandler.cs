﻿using Application.Requests;
using Application.Responses;
using AutoMapper;
using Domain.Models;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Application.Commands;

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

            var response = _mapper.Map<PostUserResponse>(_userRepository.CreateUser(newUser));
            response.StatusCode = HttpStatusCode.OK;

            return Task.FromResult(response);
        }
        catch(Exception ex)
        {
            _logger.LogInformation($"Internal server error - Error trace: {ex.StackTrace}", DateTime.UtcNow);
            throw;
        }
    }
}

