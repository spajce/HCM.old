using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class EmployeeAllowance
    {
        public int IdEmployeeAllowance { get; set; }
        /// <summary>
        /// Per Payroll / Monthly /  Per Present Day
        /// </summary>
        public string? Frequency { get; set; }
        /// <summary>
        /// refer to http://support.payrollhero.com/knowledge-base/how-to-set-up-employees-allowances/
        /// </summary>
        public string? VariabilityType { get; set; }
        public bool? IsDoubleHoliday { get; set; }
        public bool? IsRegular { get; set; }
        public bool? IsRegularHoliday { get; set; }
        public bool? IsSpecialHoliday { get; set; }
        /// <summary>
        /// ref to http://support.payrollhero.com/knowledge-base/how-to-set-up-employees-allowances/
        /// </summary>
        public string? Destination { get; set; }
        public int? IdEmployee { get; set; }
        public int? IdAllowanceParticular { get; set; }

        public virtual AllowanceParticular? IdAllowanceParticularNavigation { get; set; }
    }
}
