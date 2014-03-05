using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.Model.Model;

namespace WebApp.ViewModels
{
    public class PersonViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public AddressViewModel HomeAddress { get; set; }
        public AddressViewModel BusinessAddress { get; set; }
    }
}