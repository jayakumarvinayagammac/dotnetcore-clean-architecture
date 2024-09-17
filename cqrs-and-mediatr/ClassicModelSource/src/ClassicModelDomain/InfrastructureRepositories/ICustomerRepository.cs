using ClassicModelDomain.DomainModels;

namespace ClassicModelDomain.InfrastructureRepositories;

public interface ICustomerRepository
{
    Task<IEnumerable<CustomerTransactionModel>> GetCustomerTransactionAsync(int customerNumber);
}