using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class SssDetailDto
    {
        public int IdSssDetail { get; set; }
        public int? IdSssContribution { get; set; }
        public SssDto? IdSssContributionNavigation { get; set; }
    }
}