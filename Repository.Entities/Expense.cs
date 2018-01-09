using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
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

        //public int? Cat_id { get; set; }
        //public int? Sub_Cat_id { get; set; }        
        
        public virtual Category Category { get; set; }
      
        public virtual SubCategory SubCategory { get; set; }
    }
}
