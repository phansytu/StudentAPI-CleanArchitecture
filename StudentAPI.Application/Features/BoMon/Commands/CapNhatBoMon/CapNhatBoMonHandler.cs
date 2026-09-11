
using AutoMapper;
using MediatR;
using StudentAPI.Application.Common.Exceptions;
using StudentAPI.Application.Common.Interfaces;
using BoMonEntity = StudentAPI.Domain.Entities.BoMon;

namespace StudentAPI.Application.Features.BoMon.Commands.CapNhatBoMon;

public class CapNhatBoMonCommandHandler : IRequestHandler<CapNhatBoMonCommand, bool>
{
    private readonly IBoMonRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CapNhatBoMonCommandHandler(
        IBoMonRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CapNhatBoMonCommand request, CancellationToken cancellationToken)
    {
        var boMon = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (boMon == null)
        {
            throw new NotFoundException(nameof(BoMonEntity), request.Id);
        }

        var boMonTheoMa = await _repository.GetByMaBoMonAsync(request.MaBoMon, cancellationToken);
        if (boMonTheoMa != null && boMonTheoMa.Id != request.Id)
        {
            throw new BadRequestException($"Mã bộ môn '{request.MaBoMon}' đã được sử dụng bởi bộ môn khác.");
        }
        var boMonTheoTen = await _repository.GetByTenBoMonAsync(request.TenBoMon, cancellationToken);
        if (boMonTheoTen != null && boMonTheoTen.Id != request.Id)
        {
            throw new BadRequestException($"Tên bộ môn '{request.TenBoMon}' đã được sử dụng bởi bộ môn khác.");
        }

        // 4. Map dữ liệu cập nhật đè lên Entity đã tìm thấy
        _mapper.Map(request, boMon);

        // 5. Cập nhật và Lưu xuống DB
        _repository.Update(boMon);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}