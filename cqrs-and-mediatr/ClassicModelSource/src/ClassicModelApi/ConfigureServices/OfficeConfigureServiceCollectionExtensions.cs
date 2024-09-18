using ClassicModelApplication.Commands;
using ClassicModelApplication.DataTransferObjects;
using ClassicModelApplication.Handlers;
using ClassicModelApplication.Queries;
using ClassicModelDomain.InfrastructureRepositories;
using ClassicModelInfrastructure.Repositories;
using MediatR;

namespace ClassicModelApi;

public static class OfficeConfigureServiceCollectionExtensions
{
    public static IServiceCollection AddAndConfigureOfficeService(this IServiceCollection services)
    {
        // Repository
        services.AddScoped<IOfficeRepository, OfficeRepository>();
        // Handler
        services.AddTransient<IRequestHandler<GetOfficeQuery, IEnumerable<OfficeDTO>>, GetOfficeQueryHandler>();
        services.AddTransient<IRequestHandler<CreateOfficeCommand, OfficeCreationResult>, CreateOfficeCommandHandler>();        
        services.AddTransient<IRequestHandler<RemoveOfficeCommand, OfficeRemoveResult>, RemoveOfficeCommandHandler>(); 
        return services;
    }
}
