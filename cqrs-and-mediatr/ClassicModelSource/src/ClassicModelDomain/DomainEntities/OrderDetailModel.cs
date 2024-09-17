namespace ClassicModelDomain.DomainModels;

public class OrderDetailModel
{
    public int OrderNumber { get; private set; }

    public string ProductCode { get; private set; } = null!;

    public int QuantityOrdered { get; private set; }

    public decimal PriceEach { get; private set; }

    public short OrderLineNumber { get; private set; }

    private OrderDetailModel(int orderNumber, string productCode, int quantityOrdered, decimal priceEach, short orderLineNumber)
        => (OrderNumber, ProductCode, QuantityOrdered, PriceEach, OrderLineNumber) = (orderNumber, productCode, quantityOrdered, priceEach, orderLineNumber);
    public static OrderDetailModel Create(int orderNumber, string productCode, int quantityOrdered, decimal priceEach, short orderLineNumber)
        => new OrderDetailModel(orderNumber, productCode, quantityOrdered, priceEach, orderLineNumber );
}

