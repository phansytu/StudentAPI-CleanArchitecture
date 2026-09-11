using System.Text.Json;
using MediatR;
using StudentAPI.Application.Common.Interfaces;

namespace StudentAPI.Application.Common.Behaviors;

public class AuditLoggingBehaviorVoid<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand
    where TResponse : struct
{
    public async Task<TResponse> Handle(
        TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
    {
        var requestName = typeof(TRequest).Name;
        Console.WriteLine($"[AUDIT] {DateTime.UtcNow:O} - Bắt đầu: {requestName} - {JsonSerializer.Serialize(request)}");

        var response = await next();

        Console.WriteLine($"[AUDIT] {DateTime.UtcNow:O} - Kết thúc: {requestName} - OK");

        return response;
    }
}