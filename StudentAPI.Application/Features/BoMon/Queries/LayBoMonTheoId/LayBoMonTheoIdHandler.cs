using AutoMapper;
using MediatR;
using StudentAPI.Application.Common.Exceptions;
using StudentAPI.Application.Common.Interfaces;
using StudentAPI.Application.Features.BoMon.Common;
using BoMonEntity = StudentAPI.Domain.Entities.BoMon;

namespace StudentAPI.Application.Features.BoMon.Queries.LayBoMonTheoId;

public class LayBoMonTheoIdQueryHandler : IRequestHandler<LayBoMonTheoIdQuery, BoMonDto>
{
    private readonly IBoMonRepository _repository;
    private readonly IMapper _mapper;

    public LayBoMonTheoIdQueryHandler(IBoMonRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<BoMonDto> Handle(LayBoMonTheoIdQuery request, CancellationToken cancellationToken)
    {
        var boMon = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (boMon == null)
        {
            throw new NotFoundException(nameof(BoMonEntity), request.Id);
        }

        return _mapper.Map<BoMonDto>(boMon);
    }
}