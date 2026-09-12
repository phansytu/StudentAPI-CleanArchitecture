using AutoMapper;
using StudentAPI.Application.Features.BoMon.Commands.CapNhatBoMon;
using StudentAPI.Application.Features.BoMon.Commands.TaoBoMon;
using StudentAPI.Application.Features.BoMon.Common;
using StudentAPI.Domain.Entities;

namespace StudentAPI.Application.Common.Mappings;

public class BoMonProfile : Profile
{
    public BoMonProfile()
    {
        // Tự động map từ BoMon Entity -> BoMonDto
        CreateMap<BoMon, BoMonDto>();
        CreateMap<TaoBoMonCommand, BoMon>();
        CreateMap<CapNhatBoMonCommand, BoMon>();
    }
}