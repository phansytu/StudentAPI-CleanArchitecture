using System.Data;
using Dapper;
using MediatR;
using StudentAPI.Application.Common.Interfaces;
using StudentAPI.Application.DTOs;

namespace StudentAPI.Application.Features.BaoCao.Queries.LayThongKeTongQuan;


public class LayThongKeTongQuanHandler : IRequestHandler<LayThongKeTongQuanQuery, ThongKeTongQuanDto>
{
    private readonly ISqlConnectionFactory _connectionFactory;

    public LayThongKeTongQuanHandler(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<ThongKeTongQuanDto> Handle(
        LayThongKeTongQuanQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _connectionFactory.CreateConnection();

        var result = await connection.QueryFirstOrDefaultAsync<ThongKeTongQuanDto>(
            "sp_Dashboard_GetSummaryStats",
            commandType: CommandType.StoredProcedure
        );

        return result ?? new ThongKeTongQuanDto();
    }
}