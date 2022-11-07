using System.Collections.Generic;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class SssDto
    {
        public int IdSss { get; set; }
        public string? SssName { get; set; }
        public bool? Active { get; set; }
        public ICollection<SssDetailDto> SssDetails { get; set; }
    }
}