using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CommonEntities.Response;
using AutoMapper;
using IRepository.Interfaces;
using Business.Entities;


namespace Repository.Repositories
{
    public class ExpenseRepository : BaseRepository<ExpenseRepository>, IExpenseRepository
    {

        private readonly IMapper _mapper;
        
        public ExpenseRepository(ILogger<ExpenseRepository> logger, ExpenseDbContext context,IMapper mapper) : base(logger, context)
        {
            _mapper = mapper;
        }

        public Result<int> CreateExpense(Business.Entities.Expense expenseModel)
        {
            throw new NotImplementedException();
        }

        public Result DeleteExpense(int expenseId, string modifiedBy)
        {
            throw new NotImplementedException();
        }

        public Result<Business.Entities.Expense> GetExpense(int expenseId)
        {
            throw new NotImplementedException();
        }

        public Result<List<Business.Entities.Expense>> GetExpenses()
        {
            List<Repository.Entities.Expense> dbExpenses = _dbContext
                .Expenses
                .AsNoTracking()
                .ToList();

            if(dbExpenses.Count == 0)
            {
                return Result.Fail<List<Business.Entities.Expense>>("No Expenses are found");
            }
            return Result.Ok<List<Business.Entities.Expense>>(_mapper.Map<List<Business.Entities.Expense>>(dbExpenses));
        }

        public Result UpdateExpense(Business.Entities.Expense expenseModel)
        {
            throw new NotImplementedException();
        }
    }
}
