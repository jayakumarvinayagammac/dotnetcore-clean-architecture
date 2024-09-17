using AutoMapper;
using ClassicModelApplication.DataTransferObjects;
using ClassicModelApplication.Queries;
using ClassicModelCommon.Generics;
using ClassicModelDomain.InfrastructureRepositories;

namespace ClassicModelApplication.Handlers;

public class GetOfficeQueryHandler : IQueryHandler<GetOfficeQuery, IEnumerable<OfficeDTO>>
{
    private readonly IOfficeRepository _officeRepository;
    private readonly IMapper _mapper;
    public GetOfficeQueryHandler(IOfficeRepository officeRepository, IMapper mapper)
        => (_officeRepository, _mapper) = (officeRepository, mapper);
    public async Task<IEnumerable<OfficeDTO>> Handle(GetOfficeQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var offices = await _officeRepository.GetOfficeAsync();
            IEnumerable<OfficeDTO> officesResult = _mapper.Map<IEnumerable<OfficeDTO>>(offices);
            return officesResult;
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}