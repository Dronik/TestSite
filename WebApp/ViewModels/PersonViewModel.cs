using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Test.Model.Model;

namespace WebApp.ViewModels
{
    public class PersonViewModel
    {
        [Required]
        [DisplayName("First name:")]
        public string FirstName { get; set; }
        
        [Required]
        [DisplayName("Last name:")]
        public string LastName { get; set; }
        
        [Range(18, 100)]
        [Required]
        [DisplayName("Age:")]
        public int? Age { get; set; }

        public AddressViewModel HomeAddress { get; set; }
        public AddressViewModel BusinessAddress { get; set; }
    }
}