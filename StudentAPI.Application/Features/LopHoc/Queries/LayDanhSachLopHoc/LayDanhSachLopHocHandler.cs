using AutoMapper;
using MediatR;
using StudentAPI.Application.Common.Interface;
using StudentAPI.Application.Common.Models;
using StudentAPI.Application.Features.LopHoc.Common;

namespace StudentAPI.Application.Features.LopHoc.Queries.LayDanhSachLopHoc;

public class LayDanhSachLopHocQueryHandler : IRequestHandler<LayDanhSachLopHocQuery, PageResponse<LopHocDto>>
{
    private readonly ILopHocRepository _repository;
    private readonly IMapper _mapper;

    public LayDanhSachLopHocQueryHandler(ILopHocRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PageResponse<LopHocDto>> Handle(LayDanhSachLopHocQuery request, CancellationToken cancellationToken)
    {

        var (data, totalCount) = await _repository.GetAllLopHocAsync(
            request.PageIndex,
            request.PageSize,
            cancellationToken
        );


        var items = _mapper.Map<List<LopHocDto>>(data);


        return new PageResponse<LopHocDto>(
            items,
            totalCount,
            request.PageIndex,
            request.PageSize);
    }
}