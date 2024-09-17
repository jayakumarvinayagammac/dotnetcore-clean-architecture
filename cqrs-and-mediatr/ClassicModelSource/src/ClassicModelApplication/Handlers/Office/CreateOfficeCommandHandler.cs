using AutoMapper;
using ClassicModelApplication.Commands;
using ClassicModelApplication.DataTransferObjects;
using ClassicModelCommon.Generics;
using ClassicModelDomain.DomainEntities;
using ClassicModelDomain.InfrastructureRepositories;

namespace ClassicModelApplication.Handlers;

public class CreateOfficeCommandHandler : ICommandHandler<CreateOfficeCommand, OfficeCreationResult>
{
    private readonly IOfficeRepository _officeRepository;
    private readonly IMapper _mapper;
    public CreateOfficeCommandHandler(IOfficeRepository officeRepository, IMapper mapper)
        => (_officeRepository, _mapper) = (officeRepository, mapper);
    public async Task<OfficeCreationResult> Handle(CreateOfficeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var office = _mapper.Map<OfficeModel>(request.Office);
            var officeCode = await _officeRepository.CreatetOfficeAsync(office);            
            return new OfficeCreationResult(officeCode);;    
        }
        catch (System.Exception)
        {
            
            throw;
        }
        
    }
}