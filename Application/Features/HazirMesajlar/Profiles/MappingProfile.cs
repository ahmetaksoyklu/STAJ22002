using Application.Features.HazirMesajlar.Commands.Create;
using Application.Features.HazirMesajlar.Commands.Delete;
using Application.Features.HazirMesajlar.Commands.Update;
using Application.Features.HazirMesajlar.Queries.GetById;
using Application.Features.HazirMesajlar.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.HazirMesajlar.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<HazirMesaj, CreateHazirMesajCommand>().ReverseMap();
        CreateMap<HazirMesaj, CreatedHazirMesajResponse>().ReverseMap();

        CreateMap<HazirMesaj, UpdateHazirMesajCommand>().ReverseMap();
        CreateMap<HazirMesaj, UpdatedHazirMesajResponse>().ReverseMap();

        CreateMap<HazirMesaj, DeletedHazirMesajResponse>().ReverseMap();
        CreateMap<HazirMesaj, GetByIdHazirMesajResponse>().ReverseMap();
        CreateMap<HazirMesaj, GetListHazirMesajListItem>().ReverseMap();
    }
}
