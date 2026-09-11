using StudentAPI.Domain.Entities;

namespace StudentAPI.Application.Common.Interfaces;

public interface ILopHocRepository
{
    Task<(List<LopHoc> data, int totalCount)> GetAllLopHocAsync(
        int pageIndex,
        int pageSize,
        CancellationToken cancellationToken = default);

    Task<LopHoc?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<bool> IsMaLopUniqueAsync(string maLop, CancellationToken cancellationToken = default);

    Task AddAsync(LopHoc lopHoc, CancellationToken cancellationToken = default);

    Task UpdateAsync(LopHoc lopHoc);

    void Delete(LopHoc lopHoc);
}