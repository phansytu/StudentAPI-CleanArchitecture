
using MediatR;
using StudentAPI.Application.Common.Exceptions;
using StudentAPI.Application.Common.Interfaces;
using BoMonEntity = StudentAPI.Domain.Entities.BoMon;
namespace StudentAPI.Application.Features.BoMon.Commands.XoaBoMon;

public class XoaBoMonCommandHandler : IRequestHandler<XoaBoMonCommand, bool>
{
    private readonly IBoMonRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public XoaBoMonCommandHandler(IBoMonRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(XoaBoMonCommand request, CancellationToken cancellationToken)
    {

        var boMon = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (boMon == null)
        {
            throw new NotFoundException(nameof(BoMonEntity), request.Id);
        }
        _repository.Delete(boMon);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}