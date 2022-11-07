using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class PhilHealthDetailDto
    {
        public int IdPhilHealthDetail { get; set; }
        public int? IdPhilHealth { get; set; }
        public PhilHealthDto? IdPhilHealthNavigation { get; set; }
    }
}