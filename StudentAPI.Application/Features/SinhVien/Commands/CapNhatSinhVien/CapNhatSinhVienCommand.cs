using StudentAPI.Application.Common.Interfaces;

namespace StudentAPI.Application.Features.SinhVien.Commands.CapNhatSinhVien;

public record CapNhatSinhVienCommand(
    int id,
    string MaSV,
    string HoTen,
             bool GioiTinh,
             DateTime NgaySinh,
              string Email,
             decimal DiemTB,
              int lopHocId) : ICommand<bool>;