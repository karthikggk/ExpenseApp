using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class SubCategory
    {
        public SubCategory()
        {
            this.Expenses = new HashSet<Expense>();
        }
        public int Sub_Cat_id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
