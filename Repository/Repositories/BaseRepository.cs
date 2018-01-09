using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public abstract class BaseRepository<T>
    {
        protected readonly ILogger<T> _logger;
        protected readonly ExpenseDbContext _dbContext;

        public BaseRepository(ILogger<T> logger, ExpenseDbContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        
    }
}
