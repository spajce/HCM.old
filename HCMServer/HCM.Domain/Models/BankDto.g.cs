namespace HCM.Domain.DTOs
{
    public partial class BankDto
    {
        public int IdBank { get; set; }
        public string? BankName { get; set; }
        public string? Branch { get; set; }
        public string? Code { get; set; }
    }
}