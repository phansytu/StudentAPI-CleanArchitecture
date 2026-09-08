using StudentAPI.Domain.Entities;

namespace StudentAPI.Application.Common.Interface;

public interface IBoMonRepository
{
    Task<(List<BoMon> Data, int TotalCount)> GetAllAsync
    (
        int pageIndex,
        int pageSize,
        string? searchTerm,
        CancellationToken cancellationToken = default
        );
    Task<BoMon?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<BoMon?> GetByMaBoMonAsync(string maBoMon, CancellationToken cancellationToken);
    Task<BoMon?> GetByTenBoMonAsync(string tenBoMon, CancellationToken cancellationToken);
    Task AddAsync(BoMon boMon);
    Task UpdateAsync(BoMon boMon);
    Task DeleteAsync(BoMon boMon);
}