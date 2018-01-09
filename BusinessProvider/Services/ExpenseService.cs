using IBusiness.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using CommonEntities.Response;
using IRepository.Interfaces;

namespace BusinessProvider.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
        public Result<List<Expense>> DeleteExpenses()
        {
            throw new NotImplementedException();
        }

        public Result<Expense> GetExpense()
        {
            throw new NotImplementedException();
        }

        public Result<List<Expense>> GetExpenses()
        {
            return _expenseRepository.GetExpenses();
        }

        public Result<List<Expense>> UpdateExpenses(Expense expenseModel)
        {
            throw new NotImplementedException();
        }
    }
}
