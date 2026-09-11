using MediatR;

namespace StudentAPI.Application.Features.BoMon.Commands.XoaBoMon;

public record XoaBoMonCommand(int Id) : IRequest<bool>;