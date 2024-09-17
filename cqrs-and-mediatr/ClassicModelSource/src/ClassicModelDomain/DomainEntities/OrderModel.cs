
namespace ClassicModelDomain.DomainModels;

public class OrderModel
{
    public int OrderNumber { get; set; }

    public DateTime OrderOn { get; set; }

    public DateTime RequiredOn { get; set; }

    public DateTime? ShippedOn { get; set; }

    public string Status { get; set; } = null!;

    public string? Comments { get; set; }

    public int CustomerNumber { get; set; }

    private OrderModel(int orderNumber, DateTime orderOn, DateTime requiredOn, DateTime shippedOn, string status, string? comments, int customerNumber)
    => (OrderNumber, OrderOn, RequiredOn, ShippedOn, Status, Comments, CustomerNumber) = (orderNumber, orderOn, requiredOn, shippedOn, status, comments, customerNumber);
    public static OrderModel Create(int orderNumber, DateTime orderOn, DateTime requiredOn, DateTime shippedOn, string status, string? Comments, int customerNumber)
        => new OrderModel(orderNumber, orderOn, requiredOn, shippedOn, status, Comments, customerNumber);
}

