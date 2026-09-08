using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using StudentAPI.Application.Common.Interface;
using StudentAPI.Application.Common.Models;
using StudentAPI.Application.Features.SinhVien.Common;


namespace StudentAPI.Application.Features.SinhVien.Queries.LayDanhSachSinhVien;

public class LayDanhSachSinhVienQueryHandler
    : IRequestHandler<LayDanhSachSinhVienQuery, PageResponse<SinhVienDto>>
{
    private readonly ISinhVienRepository _repository;
    private readonly IMapper _mapper;


    public LayDanhSachSinhVienQueryHandler(
        ISinhVienRepository repository,
        IMapper mapper
        )
    {
        _repository = repository;
        _mapper = mapper;

    }

    public async Task<PageResponse<SinhVienDto>> Handle(
        LayDanhSachSinhVienQuery request,
        CancellationToken cancellationToken)
    {
        var (items, totalCount) = await _repository.GetPagedAsync(
        request.KeyWord,
        request.GioiTinh,
        request.DiemTu,
        request.DiemDen,
        request.SortBy,
        request.Descending,
        request.PageIndex,
        request.PageSize,
        cancellationToken);


        var dtos = _mapper.Map<List<SinhVienDto>>(items);
        return new PageResponse<SinhVienDto>(
            dtos,
            totalCount,
            request.PageIndex,
            request.PageSize);
    }
}