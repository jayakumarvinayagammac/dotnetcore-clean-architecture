using ClassicModelApplication.Commands;
using ClassicModelApplication.DataTransferObjects;
using ClassicModelApplication.Handlers;
using ClassicModelApplication.Queries;
using ClassicModelDomain.InfrastructureRepositories;
using ClassicModelInfrastructure.Repositories;
using MediatR;

namespace ClassicModelApi;

public static class OrderConfigureServiceCollectionExtensions
{
    public static IServiceCollection AddAndConfigureOrderService(this IServiceCollection services)
    {
        // Repository
        services.AddScoped<IOrderRepository, OrderRepository>();
        // Handler      
        services.AddTransient<IRequestHandler<GetOrderDetailQuery, IEnumerable<OrderDetailDTO>>, GetOrderDetailQueryHandler>();          
        return services;
    }
}
