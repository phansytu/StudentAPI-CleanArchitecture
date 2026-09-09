using VLXD.Application.Common.Interfaces;

namespace StudentAPI.Application.Features.LopHoc.Commands.CapNhatLopHoc;

public record CapNhatLopHocCommand
(
    int id,
    string maLop,
    string TenLop,
           string ChuyenNganh,
            int boMonId
) : ICommand<bool>;