using System.Collections.Generic;

namespace Test.Model.Model
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Orders = new List<Order>();
        }

        public string Name { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
