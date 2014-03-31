using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ViewModels
{
    [Serializable]
    public class BaseFilterViewModel
    {
        public BaseFilterViewModel()
        {
            PageNumber = 1;
        }

        public int PageNumber { get; set; }

        public string SortColumn { get; set; }
        public bool IsAscending { get; set; }
        public bool IsApply { get; set; }
    }
}