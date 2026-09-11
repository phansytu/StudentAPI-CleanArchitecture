
using AutoMapper;
using MediatR;
using StudentAPI.Application.Common.Exceptions;
using StudentAPI.Application.Common.Interfaces;
using StudentAPI.Application.Features.SinhVien.Common;

namespace StudentAPI.Application.Features.SinhVien.Commands.XoaSinhVien;

public class XoaSinhVienHandler : IRequestHandler<XoaSinhVienCommand, bool>
{
    private readonly ISinhVienRepository _sinhVienRepository;
    private readonly IUnitOfWork _unitOfWork;

    public XoaSinhVienHandler(ISinhVienRepository sinhVienRepository, IUnitOfWork unitOfWork)
    {
        _sinhVienRepository = sinhVienRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(XoaSinhVienCommand request, CancellationToken cancellationToken)
    {
        var sinhVien = await _sinhVienRepository.GetByIdAsync(request.id, cancellationToken);
        if (sinhVien == null)
        {
            throw new NotFoundException(nameof(SinhVien), request.id);

        }
        await _sinhVienRepository.DeleteAsync(sinhVien);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }


}