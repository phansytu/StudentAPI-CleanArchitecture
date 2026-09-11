using StudentAPI.Application.Common.Interfaces;

namespace StudentAPI.Application.Features.SinhVien.Commands.TaoSinhVien;

public record TaoSinhVienCommand(string HoTen,
             bool GioiTinh,
             DateTime NgaySinh,
              string Email,
             decimal DiemTB,
              int lopHocId) : ICommand<int>;