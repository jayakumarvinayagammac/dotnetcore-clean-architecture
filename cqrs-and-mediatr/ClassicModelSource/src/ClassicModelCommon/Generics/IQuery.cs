
using MediatR;

namespace ClassicModelCommon.Generics;
public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
{   }
