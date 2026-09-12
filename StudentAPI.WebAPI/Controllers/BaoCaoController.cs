using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Application.Features.BaoCao.Queries.LayThongKeTheoLop;
using StudentAPI.Application.Features.BaoCao.Queries.LayThongKeTongQuan;

namespace StudentAPI.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaoCaoController : ControllerBase
{
    private readonly IMediator _mediator;

    public BaoCaoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("thong-ke-theo-lop")]
    public async Task<IActionResult> GetThongKeTheoLop([FromQuery] int? boMonId)
    {
        var result = await _mediator.Send(new LayThongKeLopHocQuery(boMonId));
        return Ok(result);
    }
    [HttpGet("summary")]
    public async Task<IActionResult> GetSummaryStats()
    {
        var result = await _mediator.Send(new LayThongKeTongQuanQuery());
        return Ok(result);
    }
}