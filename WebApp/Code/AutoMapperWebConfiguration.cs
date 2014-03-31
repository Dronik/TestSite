using AutoMapper;
using Test.Logic.Filters;
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

            Mapper.CreateMap<PersonViewModel, Person>();
            Mapper.CreateMap<AddressViewModel, Address>();

            Mapper.CreateMap<PersonsListFilterViewModel, PersonFilter>();
            Mapper.CreateMap<PersonFilter, PersonsListFilterViewModel>();
        }
    }
}