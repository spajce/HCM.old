using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class EmployeeDependent
    {
        public int IdEmployeeDependent { get; set; }
        public int? IdEmployee { get; set; }
    }
}
