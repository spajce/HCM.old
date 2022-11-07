using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class CompanyDetail
    {
        public int IdCompanyDetails { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public string? Logo { get; set; }
    }
}
