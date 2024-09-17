
using MediatR;

namespace ClassicModelCommon.Generics;

public interface IQueryHandler< in TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : IQuery<TResponse> where TResponse : notnull
{
    
}