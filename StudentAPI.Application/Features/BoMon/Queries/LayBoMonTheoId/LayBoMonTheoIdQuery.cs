using MediatR;
using StudentAPI.Application.Features.BoMon.Common;

namespace StudentAPI.Application.Features.BoMon.Queries.LayBoMonTheoId;

public record LayBoMonTheoIdQuery(int Id) : IRequest<BoMonDto>;