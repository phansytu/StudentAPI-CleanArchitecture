using AutoMapper;
using MediatR;
using StudentAPI.Application.Common.Exceptions;
using StudentAPI.Application.Common.Interface;
using StudentAPI.Application.Features.SinhVien.Common;

namespace StudentAPI.Application.Features.SinhVien.Queries.LaySinhVienTheoId;

public class LaySinhVienTheoIdHandler : IRequestHandler<LaySinhVienTheoIdQuery, SinhVienDto>
{

    private readonly ISinhVienRepository _sinhVienRepository;
    private readonly Mapper _mapper;
    public LaySinhVienTheoIdHandler(
        ISinhVienRepository sinhVienRepository,
        Mapper mapper)
    {
        _sinhVienRepository = sinhVienRepository;
        _mapper = mapper;
    }

    public async Task<SinhVienDto> Handle(LaySinhVienTheoIdQuery request, CancellationToken cancellationToken)
    {
        var sinhVien = await _sinhVienRepository.GetByIdAsync(request.id, cancellationToken);
        if (sinhVien == null)
        {
            throw new NotFoundException(nameof(SinhVien), request.id);
        }
        return _mapper.Map<SinhVienDto>(sinhVien);
    }
}