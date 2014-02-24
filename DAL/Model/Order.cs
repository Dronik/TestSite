using System;
using System.Collections.Generic;

namespace Test.Model.Model
{
    public class Order : BaseEntity
    {

        public Order()
        {
            Products = new List<Product>();
        }

        public DateTime Date { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
