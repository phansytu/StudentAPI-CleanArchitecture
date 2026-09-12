using Dapper;
using MediatR;
using StudentAPI.Application.Common.Interfaces;
using StudentAPI.Application.DTOs;

namespace StudentAPI.Application.Features.BaoCao.Queries.LayBaoCaoChiTietSinhVien;

public class LayBaoCaoChiTietSinhVienHandler
    : IRequestHandler<LayBaoCaoChiTietSinhVienQuery, IEnumerable<BaoCaoChiTietSinhVienDto>>
{
    private readonly ISqlConnectionFactory _connectionFactory;

    public LayBaoCaoChiTietSinhVienHandler(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<BaoCaoChiTietSinhVienDto>> Handle(
        LayBaoCaoChiTietSinhVienQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _connectionFactory.CreateConnection();

        var sql = @"
            SELECT 
                SinhVienId,
                MaSinhVien,
                HoTen,
                GioiTinh,
                GioiTinhText,
                NgaySinh,
                Tuoi,
                Email,
                DiemTB,
                XepLoai,
                LopHocId,
                MaLop,
                TenLop,
                ChuyenNganh,
                BoMonId,
                TenBoMon
            FROM dbo.vw_BaoCao_ChiTietSinhVien
            WHERE (@SinhVienId IS NULL OR SinhVienId = @SinhVienId)
              AND (@LopHocId IS NULL OR LopHocId = @LopHocId)
              AND (@BoMonId IS NULL OR BoMonId = @BoMonId)
              AND (@Keyword IS NULL OR HoTen LIKE N'%' + @Keyword + '%' OR MaSinhVien LIKE '%' + @Keyword + '%')";

        var result = await connection.QueryAsync<BaoCaoChiTietSinhVienDto>(
            sql,
            new
            {
                request.SinhVienId,
                request.LopHocId,
                request.BoMonId,
                request.Keyword
            }
        );

        return result;
    }
}