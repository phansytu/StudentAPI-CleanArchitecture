using StudentAPI.Application.Common.Interfaces;
using StudentAPI.Application.Features.LopHoc.Common;

namespace StudentAPI.Application.Features.LopHoc.Queries.LayLopHocTheoId;

public record LayLopHocTheoIdQuery(int Id) : IQuery<LopHocDto>;