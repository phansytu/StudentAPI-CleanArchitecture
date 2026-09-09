using MediatR;
using StudentAPI.Application.Common.Models;
using StudentAPI.Application.Features.LopHoc.Common;


namespace StudentAPI.Application.Features.LopHoc.Queries.LayDanhSachLopHoc;

public record LayDanhSachLopHocQuery(
    int PageIndex = 1,
    int PageSize = 10
) : IRequest<PageResponse<LopHocDto>>;