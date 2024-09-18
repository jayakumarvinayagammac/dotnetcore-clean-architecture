using ClassicModelDomain.DataEntities;
using ClassicModelDomain.DomainEntities;
using ClassicModelDomain.InfrastructureRepositories;
using ClassicModelInfrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ClassicModelInfrastructure.Repositories;

public class OfficeRepository : IOfficeRepository
{
    private readonly ClassicModelsContext _classicModelsContext;
    public OfficeRepository(ClassicModelsContext classicModelsContext)
        => _classicModelsContext = classicModelsContext;

    public async Task<string> CreatetOfficeAsync(OfficeModel officeModel)
    {
        try
        {
            // Get Last OfficeCode
            IQueryable<Office> officeQuery = _classicModelsContext.Offices;
            var lastOfficeCode = await officeQuery.MaxAsync(x => Convert.ToInt64(x.OfficeCode));
            var newOffice = new Office()
            {
                OfficeCode = $"{lastOfficeCode + 1}",
                AddressLine1 = officeModel.AddressLine1!,
                AddressLine2 = officeModel.AddressLine2!,
                City = officeModel.City!,
                State = officeModel.State,
                Phone = officeModel.Phone!,
                Country = officeModel.Country!,
                PostalCode = officeModel.PostalCode!,
                Territory = officeModel.Territory!,
            };
            await _classicModelsContext.Offices.AddAsync(newOffice);
            await _classicModelsContext.SaveChangesAsync();
            return newOffice.OfficeCode;
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<OfficeModel>> GetOfficeAsync()
    {
        var offices = _classicModelsContext
                        .Offices
                        .AsNoTracking()
                        .Select(x => OfficeModel.Create(x.OfficeCode, x.City, x.Phone, x.AddressLine1, x.AddressLine2!, x.State!, x.Country, x.PostalCode, x.Territory))
                        .ToList();
        return await Task.FromResult(offices);
    }

    public Task<string> GetOfficeAsync(string officeCode)
    {
        throw new NotImplementedException();
    }

    public async Task<string> RemoveOfficeAsync(string officeCode)
    {
        try
        {
            var office = await _classicModelsContext
                            .Offices
                            .Where(x => x.OfficeCode == officeCode)
                            .FirstOrDefaultAsync();
            _classicModelsContext.Offices.Remove(office);
            await _classicModelsContext.SaveChangesAsync();
            return officeCode;
        }
        catch (System.Exception)
        {

            throw;
        }

    }
}