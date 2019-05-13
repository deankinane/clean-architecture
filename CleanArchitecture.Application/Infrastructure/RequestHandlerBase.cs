using CleanArchitecture.Persistence.DbAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Infrastructure
{
    public abstract class RequestHandlerBase<TRequest> : IRequestHandler<TRequest> where TRequest : IRequest   
    {
        protected IDbAccess _db;

        public RequestHandlerBase(IDbAccess db) => _db = db;

        public abstract Task<Unit> Handle(TRequest request, CancellationToken cancellationToken);
    }

    public abstract class RequestHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected IDbAccess _db;

        public RequestHandlerBase(IDbAccess db) => _db = db;

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
