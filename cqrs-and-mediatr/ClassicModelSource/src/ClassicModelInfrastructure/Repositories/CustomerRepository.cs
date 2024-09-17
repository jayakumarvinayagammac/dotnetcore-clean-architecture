using ClassicModelDomain.DomainModels;
using ClassicModelDomain.InfrastructureRepositories;
using ClassicModelInfrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ClassicModelInfrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ClassicModelsContext _classicModelsContext;
    public CustomerRepository(ClassicModelsContext classicModelsContext)
        => _classicModelsContext = classicModelsContext;

    public async Task<IEnumerable<CustomerTransactionModel>> GetCustomerTransactionAsync(int customerNumber)
    {
        try
        {
            var customers = Enumerable.Empty<CustomerTransactionModel>();   
            customers = _classicModelsContext.Customers
                .Where(customer => customer.CustomerNumber == customerNumber)
                .Include(customer => customer.Orders)
                .ThenInclude(order => order.Orderdetails)  
                .AsSplitQuery()              
                .SelectMany(
                    customer => customer.Orders.SelectMany(
                        order => order.Orderdetails
                        .Select(
                            orderDetail => CustomerTransactionModel.Create(
                                customer.CustomerNumber,
                                customer.CustomerName,
                                customer.Phone,
                                order.OrderNumber,
                                order.OrderDate,
                                order.Status,
                                orderDetail.QuantityOrdered,
                                orderDetail.PriceEach,
                                orderDetail.OrderLineNumber
                            )    
                        )
                    )
                )
                .ToList();            
                
            return await Task.FromResult(customers);
        }
        catch (System.Exception)
        {
            
            throw;
        }       

    }
}

/**

(int customerNumber, string? customerName, string? phone, int orderNumber,  DateTime orderDate, string? status, int quantityOrdered, decimal priceEach, short orderLineNumber)
SELECT customer.`customerNumber`, customer.`customerName`, customer.phone,
ord.`orderNumber`, ord.`orderDate`, ord.status,
orderDetail.`orderLineNumber`, orderDetail.`quantityOrdered`, orderDetail.`priceEach`
FROM customers AS customer
LEFT JOIN orders AS ord ON ord.`customerNumber` = customer.`customerNumber`
LEFT JOIN orderdetails AS orderDetail ON `orderDetail`.`orderNumber` = ord.`orderNumber`
WHERE customer.`customerNumber` = 146
LIMIT 1


dbContext
    .Orders
    .Include(order => order.LineItems)
    .ThenInclude(lineItem => lineItem.Dimensions)
    .AsSplitQuery()
    .First(order => order.Id == orderId);


SELECT o.*, li.*, d.*
FROM Orders o
LEFT JOIN LineItems li ON li.OrderId = o.Id
LEFT JOIN LineItemDimensions d ON d.LineItemId = li.Id
WHERE o.Id = @orderId
ORDER BY o.Id, li.Id, d.Id;
**/