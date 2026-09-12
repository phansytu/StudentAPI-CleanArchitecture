using Dapper;
using MediatR;
using StudentAPI.Application.Common.Interfaces;
using StudentAPI.Application.DTOs;

namespace StudentAPI.Application.Features.BaoCao.Queries.LayThongKeLopHoc;

public class LayThongKeLopHocHandler : IRequestHandler<LayThongKeLopHocQuery, IEnumerable<ThongKeLopHocDto>>
{
    private readonly ISqlConnectionFactory _connectionFactory;

    public LayThongKeLopHocHandler(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<ThongKeLopHocDto>> Handle(
        LayThongKeLopHocQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _connectionFactory.CreateConnection();

        var sql = @"
            SELECT 
                LopHocId,
                BoMonId,
                MaLop,
                TenLop,
                ChuyenNganh,
                TenBoMon,
                TongSoSinhVien,
                SoNam,
                SoNu,
                DiemTrungBinhLop,
                DiemCaoNhat,
                DiemThapNhat
            FROM dbo.vw_BaoCao_ThongKeTheoLop
            WHERE (@BoMonId IS NULL OR BoMonId = @BoMonId)";

        var result = await connection.QueryAsync<ThongKeLopHocDto>(
            sql,
            new { BoMonId = request.BoMonId }
        );

        return result;
    }
}