using BloodDonatorBackEndAspNetCoreApi.Contracts;
using BloodDonatorBackEndAspNetCoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonatorBackEndAspNetCoreApi.Contracts
{
    public interface IBloodDonatorRepository : IBaseRepository<BloodDonator>
    {
    }
}
