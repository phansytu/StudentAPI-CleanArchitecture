using AutoMapper;
using MediatR;
using StudentAPI.Application.Common.Exceptions;
using StudentAPI.Application.Common.Interface;
using StudentAPI.Application.Features.LopHoc.Common;
using LopHocEntity = StudentAPI.Domain.Entities.LopHoc;
namespace StudentAPI.Application.Features.LopHoc.Queries.LayLopHocTheoId;

public class LayLopHocTheoIdQueryHandler : IRequestHandler<LayLopHocTheoIdQuery, LopHocDto>
{
    private readonly ILopHocRepository _repository;
    private readonly IMapper _mapper;

    public LayLopHocTheoIdQueryHandler(ILopHocRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<LopHocDto> Handle(LayLopHocTheoIdQuery request, CancellationToken cancellationToken)
    {
        var lopHoc = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (lopHoc == null)
        {
            throw new NotFoundException(nameof(LopHocEntity), request.Id);
        }

        return _mapper.Map<LopHocDto>(lopHoc);
    }
}