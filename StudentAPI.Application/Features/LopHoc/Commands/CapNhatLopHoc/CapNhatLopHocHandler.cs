
using AutoMapper;
using MediatR;
using StudentAPI.Application.Common.Exceptions;
using StudentAPI.Application.Common.Interfaces;

namespace StudentAPI.Application.Features.LopHoc.Commands.CapNhatLopHoc;

public class CapNhatLopHocHandler : IRequestHandler<CapNhatLopHocCommand, bool>
{
    private readonly ILopHocRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CapNhatLopHocHandler(
        ILopHocRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CapNhatLopHocCommand request, CancellationToken cancellationToken)
    {
        var LopHoc = await _repository.GetByIdAsync(request.id, cancellationToken);
        if (LopHoc == null)
        {
            throw new NotFoundException(nameof(LopHoc), request.id);
        }
        var trungma = await _repository.IsMaLopUniqueAsync(request.maLop, cancellationToken);

        if (trungma == true)
        {
            throw new NotFoundException(nameof(LopHoc), request.maLop);
        }
        _mapper.Map(request, LopHoc);
        await _repository.UpdateAsync(LopHoc);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;

    }
}