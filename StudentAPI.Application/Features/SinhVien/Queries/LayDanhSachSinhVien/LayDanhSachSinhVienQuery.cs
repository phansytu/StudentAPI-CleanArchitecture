using MediatR;
using StudentAPI.Application.Common.Models;
using StudentAPI.Application.Features.SinhVien.Common;
using VLXD.Application.Common.Interfaces;

namespace StudentAPI.Application.Features.SinhVien.Queries.LayDanhSachSinhVien;

public record LayDanhSachSinhVienQuery(
    string? KeyWord = null,
    bool? GioiTinh = null,
    decimal? DiemTu = null,
    decimal? DiemDen = null,
    string? SortBy = null,
    bool Descending = false,
    int PageIndex = 1,
    int PageSize = 20
) : ICommand<PageResponse<SinhVienDto>>;