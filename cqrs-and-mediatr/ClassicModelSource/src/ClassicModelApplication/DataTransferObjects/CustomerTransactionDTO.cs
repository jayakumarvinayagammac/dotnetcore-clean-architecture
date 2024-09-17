namespace ClassicModelApplication.DataTransferObjects;

public record CustomerTransactionDTO(int CustomerNumber, string? CustomerName, string? Phone, int OrderNumber,  DateTime OrderDate, string? Status, int QuantityOrdered, decimal PriceEach, short OrderLineNumber);