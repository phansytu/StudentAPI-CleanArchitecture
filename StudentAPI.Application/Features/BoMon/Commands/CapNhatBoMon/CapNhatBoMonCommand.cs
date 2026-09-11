using MediatR;

namespace StudentAPI.Application.Features.BoMon.Commands.CapNhatBoMon;

public record CapNhatBoMonCommand(
    int Id,
    string MaBoMon,
    string TenBoMon
) : IRequest<bool>;