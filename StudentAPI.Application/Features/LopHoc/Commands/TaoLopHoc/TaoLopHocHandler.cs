using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Application.Common.Interface;

namespace StudentAPI.Application.Features.LopHoc.Commands.TaoLopHoc;

public class TaoLopHocHandler : IRequestHandler<TaoLopHocCommand, int>
{
    private readonly ILopHocRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TaoLopHocHandler(
        ILopHocRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<int> Handle(TaoLopHocCommand request, CancellationToken cancellationToken)
    {
        var lopHoc = _mapper.Map<Domain.Entities.LopHoc>(request);
        await _repository.AddAsync(lopHoc, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return lopHoc.Id;
    }
}