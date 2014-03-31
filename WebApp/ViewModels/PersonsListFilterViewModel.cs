using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ViewModels
{
    [Serializable]
    public class PersonsListFilterViewModel : BaseFilterViewModel
    {
        public PersonsListFilterViewModel()
        {
            SortColumn = "FirstName";
            IsAscending = true;
            IsApply = false;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int?  Age { get; set; }

    }
}