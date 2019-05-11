using AutoMapper;
using CleanArchitecture.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application
{
    public class RequestHandlerBase
    {
        protected DatabaseDbContext _context;

        public RequestHandlerBase(DatabaseDbContext context) => _context = context;
    }
}
