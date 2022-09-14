using Application.Commands.Requests;
using Application.Commands.Responses;
using AutoMapper;
using Domain.Models;

namespace UserManager.Mappers;

public class UserPatchProfileMapper : Profile
{
    public UserPatchProfileMapper()
    {
        CreateMap<PatchUserRequest, User>()
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

        CreateMap<User, PatchUserResponse>()
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

