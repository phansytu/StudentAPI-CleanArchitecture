using MediatR;
using StudentAPI.Application.Common.Interfaces;
using StudentAPI.Application.Common.Models;
using StudentAPI.Application.Features.BoMon.Common;

namespace StudentAPI.Application.Features.BoMon.Queries.LayDanhSachBoMon;

public record LayDanhSachBoMonQuery(
    int PageIndex = 1,
    int PageSize = 10,
    string? SearchTerm = null
) : IQuery<PageResponse<BoMonDto>>;