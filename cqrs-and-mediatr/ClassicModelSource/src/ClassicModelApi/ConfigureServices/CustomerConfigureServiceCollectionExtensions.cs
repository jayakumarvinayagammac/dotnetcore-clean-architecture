using ClassicModelApplication.Commands;
using ClassicModelApplication.DataTransferObjects;
using ClassicModelApplication.Handlers;
using ClassicModelApplication.Queries;
using ClassicModelDomain.InfrastructureRepositories;
using ClassicModelInfrastructure.Repositories;
using MediatR;

namespace ClassicModelApi;

public static class CustomerConfigureServiceCollectionExtensions
{
    public static IServiceCollection AddAndConfigureCustomerService(this IServiceCollection services)
    {
        // Repository
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        // Handler
        services.AddTransient<IRequestHandler<GetCustomerOrderDetailQuery, IEnumerable<CustomerTransactionDTO>>, GetCustomerOrderDetailQueryHandler>();
        return services;
    }
}
