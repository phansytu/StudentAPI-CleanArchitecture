using StudentAPI.Application.Common.Interfaces;

namespace StudentAPI.Application.Features.LopHoc.Commands.XoaLopHoc;

public record XoaLopHocCommand(
int id
) : ICommand<bool>;