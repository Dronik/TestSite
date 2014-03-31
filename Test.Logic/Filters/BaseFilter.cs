using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Logic.Filters
{
    public abstract class BaseFilter
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

        public string SortColumn { get; set; }
        public bool IsAscending { get; set; }
        public bool IsApply { get; set; }
    }
}
