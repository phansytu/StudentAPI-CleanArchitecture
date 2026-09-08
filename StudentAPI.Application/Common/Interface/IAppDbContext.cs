using StudentAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace StudentAPI.Application.Common.Interface;

public interface IAppDbContext
{
    DbSet<BoMon> BoMons { get; }
    DbSet<SinhVien> SinhViens { get; }
    DbSet<LopHoc> LopHocs { get; }
}