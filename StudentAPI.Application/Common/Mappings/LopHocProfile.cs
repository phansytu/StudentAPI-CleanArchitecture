using AutoMapper;
using StudentAPI.Application.DTOs.Response;
using StudentAPI.Application.Features.LopHoc.Commands.CapNhatLopHoc;
using StudentAPI.Application.Features.LopHoc.Commands.TaoLopHoc;
using StudentAPI.Domain.Entities;

namespace StudentAPI.Application.Common.Mappings;

public class LopHocProfile : Profile
{
    public LopHocProfile()
    {
        // Tự động map từ LopHoc Entity -> LopHocDto
        CreateMap<LopHoc, LopHocDto>();
        CreateMap<TaoLopHocCommand, LopHoc>();
        CreateMap<CapNhatLopHocCommand, LopHoc>();
    }
}