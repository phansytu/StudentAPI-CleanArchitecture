
using AutoMapper;
using MediatR;
using StudentAPI.Application.Common.Exceptions;
using StudentAPI.Application.Common.Interfaces;
using BoMonEntity = StudentAPI.Domain.Entities.BoMon;

namespace StudentAPI.Application.Features.BoMon.Commands.TaoBoMon;

public class TaoBoMonCommandHandler : IRequestHandler<TaoBoMonCommand, int>
{
    private readonly IBoMonRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TaoBoMonCommandHandler(
        IBoMonRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<int> Handle(TaoBoMonCommand request, CancellationToken cancellationToken)
    {
        var boMonTheoMa = await _repository.GetByMaBoMonAsync(request.MaBoMon, cancellationToken);
        if (boMonTheoMa != null)
        {
            throw new BadRequestException($"Mã bộ môn '{request.MaBoMon}' đã tồn tại.");
        }

        var boMonTheoTen = await _repository.GetByTenBoMonAsync(request.TenBoMon, cancellationToken);
        if (boMonTheoTen != null)
        {
            throw new BadRequestException($"Tên bộ môn '{request.TenBoMon}' đã tồn tại.");
        }

        var boMon = _mapper.Map<BoMonEntity>(request);

        await _repository.AddAsync(boMon, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return boMon.Id;
    }
}