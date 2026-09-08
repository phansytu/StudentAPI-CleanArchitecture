using System.Text.Json;
using MediatR;
using VLXD.Application.Common.Interfaces;

namespace VLXD.Application.Common.Behaviors;

// Chỉ áp dụng cho ICommand — Query (đọc dữ liệu) không cần ghi nhật ký thao tác
public class AuditLoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
    {
        var requestName = typeof(TRequest).Name;

        // TODO (bước ghi DB thật): map vào bảng NhatKyThaoTac
        // (nguoi_dung_id, hanh_dong, doi_tuong, gia_tri_truoc, gia_tri_sau, thoi_gian)
        Console.WriteLine($"[AUDIT] {DateTime.UtcNow:O} - Bắt đầu: {requestName} - {JsonSerializer.Serialize(request)}");

        var response = await next();

        Console.WriteLine($"[AUDIT] {DateTime.UtcNow:O} - Kết thúc: {requestName} - OK");

        return response;
    }
}