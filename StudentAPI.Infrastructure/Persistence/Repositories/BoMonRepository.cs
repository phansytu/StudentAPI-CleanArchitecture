
using StudentAPI.Application.Common.Interface;
using StudentAPI.Domain.Entities;

namespace StudentAPI.Infrastructure.Persistence.Repositories;

public class BoMonRepository : IBoMonRepository
{
    public Task AddAsync(BoMon boMon)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(BoMon boMon)
    {
        throw new NotImplementedException();
    }

    public Task<(List<BoMon> Data, int TotalCount)> GetAllAsync(int pageIndex, int pageSize, string? searchTerm, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<BoMon?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<BoMon?> GetByMaBoMonAsync(string maBoMon, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<BoMon?> GetByTenBoMonAsync(string tenBoMon, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(BoMon boMon)
    {
        throw new NotImplementedException();
    }
}