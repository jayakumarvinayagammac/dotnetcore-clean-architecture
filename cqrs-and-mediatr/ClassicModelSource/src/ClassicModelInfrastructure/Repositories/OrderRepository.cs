using ClassicModelDomain.DomainModels;
using ClassicModelDomain.InfrastructureRepositories;
using ClassicModelInfrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ClassicModelInfrastructure.Repositories;
public class OrderRepository : IOrderRepository
{
    private readonly ClassicModelsContext _classicModelsContext;
    public OrderRepository(ClassicModelsContext classicModelsContext)
        => _classicModelsContext = classicModelsContext;
    public async Task<IEnumerable<OrderDetailModel>> GetOrderDetailAsync()
    {        
        var orderDetails = _classicModelsContext.OrderDetails.AsNoTracking()
            .Select(x=> OrderDetailModel.Create(x.OrderNumber, x.ProductCode, x.QuantityOrdered, x.PriceEach, x.OrderLineNumber))
            .ToList();
            return await Task.FromResult(orderDetails);
    }

    public async Task<OrderDetailModel> GetOrderDetailAsync(int orderNumber)
    {
        var orderDetail = await _classicModelsContext.OrderDetails.AsNoTracking()
            .Where(x => x.OrderNumber == orderNumber)
            .Select(x=> OrderDetailModel.Create(x.OrderNumber, x.ProductCode, x.QuantityOrdered, x.PriceEach, x.OrderLineNumber))
            .FirstOrDefaultAsync();
            return orderDetail!;
    }
}

