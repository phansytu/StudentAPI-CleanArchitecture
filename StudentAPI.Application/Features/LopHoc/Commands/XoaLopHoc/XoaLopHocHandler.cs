using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using StudentAPI.Application.Common.Exceptions;
using StudentAPI.Application.Common.Interface;

namespace StudentAPI.Application.Features.LopHoc.Commands.XoaLopHoc;

public class XoaLopHocHandler : IRequestHandler<XoaLopHocCommand, bool>
{
    private readonly ILopHocRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public XoaLopHocHandler(
        ILopHocRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(XoaLopHocCommand request, CancellationToken cancellationToken)
    {
        var LopHoc = await _repository.GetByIdAsync(request.id, cancellationToken);

        if (LopHoc == null)
        {
            throw new NotFoundException(nameof(LopHoc), request.id);
        }

        _repository.Delete(LopHoc);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}