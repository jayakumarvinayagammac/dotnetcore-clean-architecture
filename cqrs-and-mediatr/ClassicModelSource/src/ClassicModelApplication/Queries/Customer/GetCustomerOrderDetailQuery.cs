using ClassicModelApplication.DataTransferObjects;
using ClassicModelCommon.Generics;

namespace ClassicModelApplication.Queries;

public record GetCustomerOrderDetailQuery(int CustomerNumber) : IQuery<IEnumerable<CustomerTransactionDTO>>;
