using AutoMapper;
using StudentAPI.Application.Features.SinhVien.Commands.CapNhatSinhVien;
using StudentAPI.Application.Features.SinhVien.Commands.TaoSinhVien;
using StudentAPI.Application.Features.SinhVien.Common;
using StudentAPI.Domain.Entities;

namespace StudentAPI.Application.Common.Mappings;

public class SinhVienProfile : Profile
{
    public SinhVienProfile()
    {
        // Tự động map từ SinhVien Entity -> SinhVienDto
        CreateMap<SinhVien, SinhVienDto>();
        CreateMap<TaoSinhVienCommand, SinhVien>();
        CreateMap<CapNhatSinhVienCommand, SinhVien>();
    }
}