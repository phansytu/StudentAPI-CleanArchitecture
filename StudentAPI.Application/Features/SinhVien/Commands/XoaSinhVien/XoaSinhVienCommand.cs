using StudentAPI.Application.Features.SinhVien.Common;
using VLXD.Application.Common.Interfaces;

namespace StudentAPI.Application.Features.SinhVien.Commands.XoaSinhVien;

public record XoaSinhVienCommand(int id) : ICommand<bool>;