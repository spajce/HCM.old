using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class EmployeeReference
    {
        public int IdEmployeeReference { get; set; }
        public int? IdEmployee { get; set; }
    }
}
