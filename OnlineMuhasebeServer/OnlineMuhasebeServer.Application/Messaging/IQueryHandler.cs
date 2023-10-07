using MediatR;

namespace OnlineMuhasebeServer.Application.Messaging
{
    internal interface IQueryHandler<in TQuery,TResponse>:IRequestHandler<TQuery,TResponse > where TQuery:IQuery<TResponse>
    {

    }
}
