
using MediatR;

namespace ClassicModelCommon.Generics;
public interface ICommand<out TResponse> : IRequest<TResponse> where TResponse : notnull
{   }
