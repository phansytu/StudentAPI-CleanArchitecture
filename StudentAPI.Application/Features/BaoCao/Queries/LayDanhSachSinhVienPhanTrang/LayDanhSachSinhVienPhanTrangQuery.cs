using System.Data;
using Dapper;
using MediatR;
using StudentAPI.Application.Common.Interfaces;
using StudentAPI.Application.Common.Models;
using StudentAPI.Application.DTOs;

namespace StudentAPI.Application.Features.SinhVien.Queries.LayDanhSachSinhVienPhanTrang;

public record LayDanhSachSinhVienPhanTrangQuery(
    int PageIndex = 1,
    int PageSize = 10,
    string? Keyword = null,
    int? LopHocId = null,
    int? BoMonId = null,
    double? MinDiem = null,
    double? MaxDiem = null
) : IQuery<PageResponse<SinhVienPagedDto>>;
