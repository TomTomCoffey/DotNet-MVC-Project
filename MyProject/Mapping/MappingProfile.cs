using AutoMapper;
using MyProject.Dtos;
using MyProject.Models;

namespace MyProject.Mapping{

    public class MappingProfile : Profile
    {
       public MappingProfile(){

              CreateMap<Customer, CustomerDto>();
              CreateMap<CustomerDto, Customer>();
       }
    }
}