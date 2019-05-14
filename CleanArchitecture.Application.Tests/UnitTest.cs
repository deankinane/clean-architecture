using AutoMapper;
using CleanArchitecture.Application.Tests.Infrastructure;
using CleanArchitecture.Persistence;
using CleanArchitecture.Persistence.DbAccess;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace CleanArchitecture.Application.Tests
{
    public abstract class UnitTest : IDisposable
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;
        private readonly DatabaseDbContext dbContext;

        protected readonly IMapper mapper;
        protected readonly DbAccess dbAccess;

        protected UnitTest()
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            _connection.Open();
            var options = new DbContextOptionsBuilder<DatabaseDbContext>()
                    .UseSqlite(_connection)
                    .Options;
            dbContext = new DatabaseDbContext(options);
            dbContext.Database.EnsureCreated();

            dbAccess = new DbAccess(dbContext);
            mapper = AutoMapperFactory.Create();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
