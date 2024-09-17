namespace ClassicModelApplication.DataTransferObjects;

public record OrderDetailDTO(int OrderNumber, string ProductCode, int QuantityOrdered, decimal PriceEach, short OrderLineNumber);