using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Business.Services.Data;
using TestProject.Domain;

namespace TestProject.Business.Configurations
{
    public class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Customer, CustomerData>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.Firstname))
                    .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.Lastname))
                    .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
                    .ReverseMap()
                    ;

                cfg.CreateMap<Address, AddressData>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
                    .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                    .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.ZipCode))
                    .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                    .ForMember(dest => dest.IsDefault, opt => opt.MapFrom(src => src.IsDefault))
                    .ReverseMap()
                    ;
            });            
        }
    }
}
