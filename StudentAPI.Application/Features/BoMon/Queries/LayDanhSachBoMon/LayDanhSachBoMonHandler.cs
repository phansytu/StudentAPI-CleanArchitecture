using AutoMapper;
using MediatR;
using StudentAPI.Application.Common.Interfaces;
using StudentAPI.Application.Common.Models;
using StudentAPI.Application.Features.BoMon.Common;

namespace StudentAPI.Application.Features.BoMon.Queries.LayDanhSachBoMon;

public class LayDanhSachBoMonQueryHandler : IRequestHandler<LayDanhSachBoMonQuery, PageResponse<BoMonDto>>
{
    private readonly IBoMonRepository _repository;
    private readonly IMapper _mapper;

    public LayDanhSachBoMonQueryHandler(IBoMonRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PageResponse<BoMonDto>> Handle(LayDanhSachBoMonQuery request, CancellationToken cancellationToken)
    {

        var (data, totalCount) = await _repository.GetAllAsync(
            request.PageIndex,
            request.PageSize,
            request.SearchTerm,
            cancellationToken
        );

        var items = _mapper.Map<List<BoMonDto>>(data);

        return new PageResponse<BoMonDto>(items, totalCount, request.PageIndex, request.PageSize);
    }
}