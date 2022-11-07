namespace HCM.Domain.DTOs
{
    public partial class CompanyDetailDto
    {
        public int IdCompanyDetails { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public string? Logo { get; set; }
    }
}