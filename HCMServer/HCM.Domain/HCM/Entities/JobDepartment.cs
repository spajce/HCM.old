using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class JobDepartment
    {
        public int IdJobDepartment { get; set; }
        public string? JobDepartmentName { get; set; }
        public int? IdEmployeeHead { get; set; }
    }
}
