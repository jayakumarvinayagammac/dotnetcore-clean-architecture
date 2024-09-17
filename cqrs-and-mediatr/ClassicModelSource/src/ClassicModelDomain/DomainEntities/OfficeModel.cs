namespace ClassicModelDomain.DomainEntities;

public class OfficeModel
{
    public string? OfficeCode { get; set; }

    public string? City { get; set; }

    public string? Phone { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? PostalCode { get; set; }

    public string? Territory { get; set; }

    private OfficeModel(string officeCode, string city, string phone, string addressLine1, string addressLine2, string state, string country, string postalCode, string territory)
        => (OfficeCode, City, Phone, AddressLine1, AddressLine2, State, Country, PostalCode, Territory) = (officeCode, city, phone, addressLine1, addressLine2, state, country, postalCode, territory);

    public static OfficeModel Create(string officeCode, string city, string phone, string addressLine1, string addressLine2, string state, string country, string postalCode, string territory)
        => new OfficeModel(officeCode, city, phone, addressLine1, addressLine2, state, country, postalCode, territory);

}