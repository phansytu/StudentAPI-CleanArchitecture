using StudentAPI.Application.Common.Models;
using StudentAPI.Domain.Entities;

namespace StudentAPI.Application.Common.Interface
{
    public interface ISinhVienRepository
    {
        Task<(List<SinhVien> Data, int TotalCount)> GetPagedAsync(
        string? keyWord,
        bool? gioiTinh,
        decimal? diemTu,
        decimal? diemDen,
        string? sortBy,
        bool descending,
        int pageIndex,
        int pageSize,
        CancellationToken cancellationToken = default);
    }

}