using MediatR;
using StudentAPI.Application.Features.LopHoc.Common;

namespace StudentAPI.Application.Features.LopHoc.Queries.LayLopHocTheoId;

public record LayLopHocTheoIdQuery(int Id) : IRequest<LopHocDto>;