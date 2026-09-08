
using StudentAPI.Domain.Entities;

namespace StudentAPI.Application.Common.Interface;

public interface ILopHocRepository
{
    Task<LopHoc?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<bool> IsMaLopUniqueAsync(string maLop, CancellationToken cancellationToken = default);
    Task AddAsync(LopHoc lopHoc, CancellationToken cancellationToken = default);
    void Update(LopHoc lopHoc);
    void Delete(LopHoc lopHoc);
}
