using ClassicModelApplication.DataTransferObjects;
using ClassicModelCommon.Generics;

namespace ClassicModelApplication.Queries;
public record GetOrderDetailQuery : IQuery<IEnumerable<OrderDetailDTO>>;
