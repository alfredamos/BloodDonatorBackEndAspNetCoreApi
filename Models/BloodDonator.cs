using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonatorBackEndAspNetCoreApi.Models
{
    public class BloodDonator
    {
        public int BloodDonatorId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string BloodGroup { get; set; }
        public string Genetype { get; set; }
        public string Address { get; set; }
    }
}
