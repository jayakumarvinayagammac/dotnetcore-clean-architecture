using ClassicModelApplication.DataTransferObjects;
using ClassicModelCommon.Generics;

namespace ClassicModelApplication.Queries;

public record GetOfficeQuery() : IQuery<IEnumerable<OfficeDTO>>;