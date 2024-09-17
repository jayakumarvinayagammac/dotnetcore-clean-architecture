namespace ClassicModelApplication.DataTransferObjects;

public record OfficeDTO(string OfficeCode, string City, string Phone, string AddressLine1, string AddressLine2, string State, string Country, string PostalCode, string Territory);

public record OfficeCreationResult(string OfficeCode);