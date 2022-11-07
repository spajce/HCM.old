using System.Collections.Generic;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class PagibigDto
    {
        public int IdPagibig { get; set; }
        public string? PagibigName { get; set; }
        public string? Active { get; set; }
        public ICollection<PagibigDetailDto> PagibigDetails { get; set; }
    }
}