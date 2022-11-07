using System.Collections.Generic;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class PhilHealthDto
    {
        public int IdPhilHealth { get; set; }
        public string? PhilHealthName { get; set; }
        public bool? Active { get; set; }
        public ICollection<PhilHealthDetailDto> PhilHealthDetails { get; set; }
    }
}