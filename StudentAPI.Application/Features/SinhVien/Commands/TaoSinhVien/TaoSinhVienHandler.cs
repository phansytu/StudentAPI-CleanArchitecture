using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using StudentAPI.Application.Common.Interface;
using StudentAPI.Domain.Entities;
namespace StudentAPI.Application.Features.SinhVien.Commands.TaoSinhVien;

public class TaoSinhVienHandler : IRequestHandler<TaoSinhVienCommand, int>
{
    private readonly ISinhVienRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public TaoSinhVienHandler(
        ISinhVienRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<int> Handle(TaoSinhVienCommand request, CancellationToken cancellationToken)
    {
        var sinhVien = _mapper.Map<Domain.Entities.SinhVien>(request);
        await _repository.AddAsync(sinhVien, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return sinhVien.Id;
    }
}

