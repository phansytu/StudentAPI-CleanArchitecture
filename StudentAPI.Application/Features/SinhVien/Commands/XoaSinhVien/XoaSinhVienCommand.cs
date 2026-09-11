using StudentAPI.Application.Features.SinhVien.Common;
using StudentAPI.Application.Common.Interfaces;

namespace StudentAPI.Application.Features.SinhVien.Commands.XoaSinhVien;

public record XoaSinhVienCommand(int id) : ICommand<bool>;