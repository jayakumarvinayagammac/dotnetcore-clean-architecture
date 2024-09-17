
using MediatR;

namespace ClassicModelCommon.Generics;

public interface ICommandHandler< in TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : ICommand<TResponse> where TResponse : notnull
{
    
}