using AutoMapper;
using BloodDonatorBackEndAspNetCoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonatorBackEndAspNetCoreApi.Mappings
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<BloodDonator, BloodDonator>().ReverseMap();           
        }
    }
}
