using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace WebApp.ViewModels
{
    [Serializable]
    public class PersonsListViewModel
    {
        public IPagedList<PersonViewModel> Items { get; set; }
        public PersonsListFilterViewModel Filter { get; set; }
    }
}