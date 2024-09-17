using AutoMapper;
using ClassicModelApplication.DataTransferObjects;
using ClassicModelApplication.Queries;
using ClassicModelCommon.Generics;
using ClassicModelDomain.InfrastructureRepositories;

namespace ClassicModelApplication.Handlers;

public class GetOrderDetailQueryHandler : IQueryHandler<GetOrderDetailQuery, IEnumerable<OrderDetailDTO>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    public GetOrderDetailQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        => (_orderRepository, _mapper) = (orderRepository, mapper);
    public async Task<IEnumerable<OrderDetailDTO>> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var orderDetails = await _orderRepository.GetOrderDetailAsync();
            IEnumerable<OrderDetailDTO> orderDetailsResult = _mapper.Map<IEnumerable<OrderDetailDTO>>(orderDetails);
            return orderDetailsResult;
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
