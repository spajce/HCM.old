using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class PagibigDetailDto
    {
        public int IdPagibigDetail { get; set; }
        public int? IdPagibig { get; set; }
        public PagibigDto? IdPagibigNavigation { get; set; }
    }
}