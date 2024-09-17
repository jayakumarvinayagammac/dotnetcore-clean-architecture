using ClassicModelDomain.DomainModels;

namespace ClassicModelDomain.InfrastructureRepositories;

public interface IOrderRepository
{
    Task<IEnumerable<OrderDetailModel>> GetOrderDetailAsync();
    Task<OrderDetailModel> GetOrderDetailAsync(int orderNumber);    
}