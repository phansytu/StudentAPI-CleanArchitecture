using MediatR;

namespace StudentAPI.Application.Features.BoMon.Commands.TaoBoMon;

public record TaoBoMonCommand(
    string MaBoMon,
    string TenBoMon
) : IRequest<int>;