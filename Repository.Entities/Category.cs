using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class Category
    {
        public Category()
        {
            this.Expenses = new HashSet<Expense>();
        }
        public int Cat_id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
