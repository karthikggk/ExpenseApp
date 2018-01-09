using Business.Entities;
using CommonEntities.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBusiness.Interfaces
{
    public interface IExpenseService
    {
        Result<List<Expense>> GetExpenses();
        Result<Expense> GetExpense();
        Result<List<Expense>> UpdateExpenses(Expense expenseModel);
        Result<List<Expense>> DeleteExpenses();
    }
}
