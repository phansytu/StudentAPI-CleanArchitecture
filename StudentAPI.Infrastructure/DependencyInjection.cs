using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentAPI.Application.Common.Interfaces;
using StudentAPI.Infrastructure.Persistence;
using StudentAPI.Infrastructure.Persistence.Repositories;

namespace StudentAPI.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
            ));

        services.AddScoped<IAppDbContext>(provider =>
            (IAppDbContext)provider.GetRequiredService<AppDbContext>());

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ISinhVienRepository, SinhVienRepository>();
        services.AddScoped<ILopHocRepository, LopHocRepository>();
        services.AddScoped<IBoMonRepository, BoMonRepository>();

        return services;
    }
}