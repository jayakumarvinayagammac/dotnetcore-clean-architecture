using AutoMapper;
using ClassicModelApplication.Commands;
using ClassicModelApplication.DataTransferObjects;
using ClassicModelCommon.Generics;
using ClassicModelDomain.InfrastructureRepositories;

namespace ClassicModelApplication.Handlers;

public class RemoveOfficeCommandHandler : ICommandHandler<RemoveOfficeCommand, OfficeRemoveResult>
{
     private readonly IOfficeRepository _officeRepository;
    public RemoveOfficeCommandHandler(IOfficeRepository officeRepository)
        => _officeRepository = officeRepository;
    public async Task<OfficeRemoveResult> Handle(RemoveOfficeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var officeCode = await _officeRepository.RemoveOfficeAsync(request.OfficeCode);
            return new OfficeRemoveResult(officeCode);
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
}