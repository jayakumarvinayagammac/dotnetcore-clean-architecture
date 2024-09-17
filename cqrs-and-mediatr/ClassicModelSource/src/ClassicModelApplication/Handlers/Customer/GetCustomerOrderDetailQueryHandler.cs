using AutoMapper;
using ClassicModelApplication.DataTransferObjects;
using ClassicModelApplication.Queries;
using ClassicModelCommon.Generics;
using ClassicModelDomain.InfrastructureRepositories;

namespace ClassicModelApplication.Handlers;

public class GetCustomerOrderDetailQueryHandler : IQueryHandler<GetCustomerOrderDetailQuery, IEnumerable<CustomerTransactionDTO>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    public GetCustomerOrderDetailQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        => (_customerRepository, _mapper) = (customerRepository, mapper);
    public async Task<IEnumerable<CustomerTransactionDTO>> Handle(GetCustomerOrderDetailQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var customerTransactionResult = await _customerRepository.GetCustomerTransactionAsync(request.CustomerNumber);
            IEnumerable<CustomerTransactionDTO> customerTransactions = _mapper.Map<IEnumerable<CustomerTransactionDTO>>(customerTransactionResult);  
            return customerTransactions;
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
}