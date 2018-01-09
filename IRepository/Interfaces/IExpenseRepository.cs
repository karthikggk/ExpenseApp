using Business.Entities;
using CommonEntities.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRepository.Interfaces
{
    public interface IExpenseRepository
    {
        Result<List<Business.Entities.Expense>> GetExpenses();
        Result<Business.Entities.Expense> GetExpense(int expenseId);
        Result UpdateExpense(Expense expenseModel);
        Result<int> CreateExpense(Expense expenseModel);
        Result DeleteExpense(int expenseId, string modifiedBy);

    }
}
