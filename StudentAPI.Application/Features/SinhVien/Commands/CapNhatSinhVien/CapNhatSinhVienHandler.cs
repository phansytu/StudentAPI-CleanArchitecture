using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using StudentAPI.Application.Common.Exceptions;
using StudentAPI.Application.Common.Interface;

namespace StudentAPI.Application.Features.SinhVien.Commands.CapNhatSinhVien;

public class CapNhatSinhVienHandler : IRequestHandler<CapNhatSinhVienCommand, bool>
{
    private readonly ISinhVienRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CapNhatSinhVienHandler(
        ISinhVienRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CapNhatSinhVienCommand request, CancellationToken cancellationToken)
    {
        var sinhVien = await _repository.GetByIdAsync(request.id, cancellationToken);
        if (sinhVien == null)
        {
            throw new NotFoundException(nameof(SinhVien), request.id);
        }
        var sinhVienCungMsv = await _repository.GetByMsvAsync(request.MaSV, cancellationToken);
        if (sinhVienCungMsv != null && sinhVienCungMsv.Id != request.id)
        {
            throw new BadRequestException($"Mã sinh viên '{request.MaSV}' đã được sử dụng bởi sinh viên khác.");
        }
        _mapper.Map(request, sinhVien);
        await _repository.UpdateAsync(sinhVien);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;

    }
}