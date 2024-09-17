using ClassicModelDomain.DomainEntities;

namespace ClassicModelDomain.InfrastructureRepositories;

public interface IOfficeRepository
{
    Task<IEnumerable<OfficeModel>> GetOfficeAsync();
    Task<string> GetOfficeAsync(string officeCode);
    Task<string> CreatetOfficeAsync(OfficeModel officeModel);
}