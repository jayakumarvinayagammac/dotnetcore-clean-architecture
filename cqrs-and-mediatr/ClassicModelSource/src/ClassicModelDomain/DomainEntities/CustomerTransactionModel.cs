namespace ClassicModelDomain.DomainModels;

public class CustomerTransactionModel
{    
    public int CustomerNumber { get; set; }
    public string? CustomerName { get; set; }
    public string? Phone { get; set; }
    public int OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public string? Status { get; set; }
    public int QuantityOrdered { get; set; }
    public decimal PriceEach { get; set; }
    public short OrderLineNumber { get; set; }

    private CustomerTransactionModel(int customerNumber, string? customerName, string? phone, int orderNumber,  DateTime orderDate, string? status, int quantityOrdered, decimal priceEach, short orderLineNumber)
        => (CustomerNumber, CustomerName, Phone, OrderNumber, OrderDate, Status, QuantityOrdered, PriceEach, OrderLineNumber ) = (customerNumber, customerName, phone, orderNumber, orderDate, status, quantityOrdered, priceEach, orderLineNumber );

    public static CustomerTransactionModel Create(int customerNumber, string? customerName, string? phone, int orderNumber,  DateTime orderDate, string? status, int quantityOrdered, decimal priceEach, short orderLineNumber)
        => new CustomerTransactionModel(customerNumber, customerName, phone, orderNumber, orderDate, status, quantityOrdered, priceEach, orderLineNumber );
}