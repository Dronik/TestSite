using AutoMapper;
using Test.Model.Model;
using WebApp.ViewModels;

namespace WebApp.Code
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Person, PersonViewModel>();
            Mapper.CreateMap<Address, AddressViewModel>();
        }
    }
}