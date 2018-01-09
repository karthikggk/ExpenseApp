using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Data.Common;
//using Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Newtonsoft.Json;
using IBusiness.Interfaces;
using AutoMapper;
using Business.Entities;
using CommonEntities.Response;
using ViewModel.Entities;

namespace ExpenseApp2.Controller
{
  [Produces("application/json")]
  [Route("api/[controller]")]
  public class ExpensesController : ControllerBase
  {
    //private ExpenseDbContext _context;
    //public ExpensesController(ExpenseDbContext context)
    //{
    //  _context = context;
    //}

    private readonly IExpenseService _expenseService;
    private readonly IMapper _mapper;

    public ExpensesController(IExpenseService expenseService, IMapper mapper)
    {
      _expenseService = expenseService;
      _mapper = mapper;
    }

    [HttpGet]
    [Route("GetExpenses")]
    public IActionResult GetAll()
    {
      Result<List<Expense>> response = null;
      try
      {
        //exp = _context.Expenses
        //                .Include(x => x.Category)
        //                .Include(x => x.SubCategory)
        //                .ToList();
        response = _expenseService.GetExpenses();
        if (!response.IsSuccessed)
        {
          return NotFound(new { errorMessage = response.GetErrorString(), expenses = new List<Expense>() });
        }
        return Ok(_mapper.Map<List<ExpensesViewModel>>(response.Value));
      }
      catch (DbException ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.Data);
        return NotFound(new { errorMessage = response.GetErrorString(), expenses = new List<Expense>() });
      }
      catch (Exception ex)
      {

      }
      finally
      {

      }
      //if (response.Count > 0)
      //  return Ok(response);
      ////Json
      //else
      //  return NotFound("There was some error");
      return NotFound("There was some problem in Expenses");
    }

    //[HttpPost]
    //[Route("AddExpense")]
    //public IActionResult ADD([FromBody]Expense expenseModel)
    //{
    //  if (expenseModel == default(Expense))
    //  {
    //    return NotFound("Its empty");
    //  }
    //  try
    //  {
    //    _context.Expenses.Add(expenseModel);
    //    _context.SaveChanges();
    //    return Ok("Successfully added");
    //  }
    //  catch (Exception ex)
    //  {
    //    Console.WriteLine(ex.Message);
    //    return NotFound("Something went wrong");
    //  }
    //}




  }
}
