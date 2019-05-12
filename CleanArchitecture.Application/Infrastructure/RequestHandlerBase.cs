using AutoMapper;
using CleanArchitecture.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Infrastructure
{
    public abstract class RequestHandlerBase<TRequest> : IRequestHandler<TRequest> where TRequest : IRequest   
    {
        protected IDatabaseDbContext _context;

        public RequestHandlerBase(IDatabaseDbContext context) => _context = context;

        public abstract Task<Unit> Handle(TRequest request, CancellationToken cancellationToken);
    }

    public abstract class RequestHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected IDatabaseDbContext _context;

        public RequestHandlerBase(IDatabaseDbContext context) => _context = context;

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
