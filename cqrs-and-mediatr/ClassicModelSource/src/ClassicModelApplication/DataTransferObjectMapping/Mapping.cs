using AutoMapper;
using ClassicModelApplication.DataTransferObjects;
using ClassicModelDomain.DomainEntities;
using ClassicModelDomain.DomainModels;

namespace ClassicModelApplication.DataTransferObjectMapping;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<OrderDetailDTO, OrderDetailModel>().DisableCtorValidation().ReverseMap();
        CreateMap<CustomerTransactionDTO, CustomerTransactionModel>().DisableCtorValidation().ReverseMap();
        CreateMap<OfficeDTO, OfficeModel>().DisableCtorValidation().ReverseMap();
    }
}