using StudentAPI.Application.Features.SinhVien.Common;
using StudentAPI.Application.Common.Interfaces;

namespace StudentAPI.Application.Features.SinhVien.Queries.LaySinhVienTheoId;

public record LaySinhVienTheoIdQuery(int id) : IQuery<SinhVienDto>;