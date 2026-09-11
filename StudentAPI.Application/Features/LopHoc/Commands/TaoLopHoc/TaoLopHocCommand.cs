using StudentAPI.Application.Common.Interfaces;

namespace StudentAPI.Application.Features.LopHoc.Commands.TaoLopHoc;

public record TaoLopHocCommand
(
    string TenLop,
           string ChuyenNganh,
            int boMonId
) : ICommand<int>;