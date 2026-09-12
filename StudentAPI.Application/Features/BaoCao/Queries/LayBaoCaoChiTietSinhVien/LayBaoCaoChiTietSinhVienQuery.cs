using StudentAPI.Application.Common.Interfaces;
using StudentAPI.Application.DTOs;

namespace StudentAPI.Application.Features.BaoCao.Queries.LayBaoCaoChiTietSinhVien;

public record LayBaoCaoChiTietSinhVienQuery(
    int? SinhVienId = null,
    int? LopHocId = null,
    int? BoMonId = null,
    string? Keyword = null
) : IQuery<IEnumerable<BaoCaoChiTietSinhVienDto>>;
