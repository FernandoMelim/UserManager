using Application.Requests;
using Application.Responses;
using AutoMapper;
using Domain.Models;

namespace Infrastructure.Mappers;

public class UserPostProfileMapper : Profile
{
    public UserPostProfileMapper()
    {
        CreateMap<PostUserRequest, User>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.Name}")
            )
            .ForMember(
                dest => dest.Surname,
                opt => opt.MapFrom(src => $"{src.Surname}")
            )
            .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => $"{src.Email}")
            )
            .ForMember(
                dest => dest.BirthDate,
                opt => opt.MapFrom(src => $"{src.BirthDate}")
            )
            .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => $"{src.Email}")
            );

        CreateMap<User, PostUserResponse>()
             .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => $"{src.Id}")
            )
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.Name}")
            )
            .ForMember(
                dest => dest.Surname,
                opt => opt.MapFrom(src => $"{src.Surname}")
            )
            .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => $"{src.Email}")
            )
            .ForMember(
                dest => dest.BirthDate,
                opt => opt.MapFrom(src => $"{src.BirthDate}")
            )
            .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => $"{src.Email}")
            );
    }
}

