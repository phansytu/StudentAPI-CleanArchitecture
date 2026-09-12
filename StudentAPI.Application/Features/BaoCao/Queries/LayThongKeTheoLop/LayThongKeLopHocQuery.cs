using StudentAPI.Application.Common.Interfaces;
using StudentAPI.Application.DTOs;

namespace StudentAPI.Application.Features.BaoCao.Queries.LayThongKeTheoLop;

public record LayThongKeLopHocQuery(int? BoMonId = null) : IQuery<IEnumerable<ThongKeLopHocDto>>;
