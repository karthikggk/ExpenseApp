using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public string Expense_Description { get; set; }
        public string Username { get; set; }
        public decimal Amount { get; set; }
        public string Is_Active { get; set; }
        public int? Category_ref_id { get; set; }
        public int? Sub_Category_ref_id { get; set; }
    }
}
