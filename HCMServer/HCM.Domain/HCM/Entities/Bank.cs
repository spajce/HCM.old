using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class Bank
    {
        public int IdBank { get; set; }
        public string? BankName { get; set; }
        public string? Branch { get; set; }
        public string? Code { get; set; }
    }
}
