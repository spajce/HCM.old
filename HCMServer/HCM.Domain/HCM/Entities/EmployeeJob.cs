using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class EmployeeJob
    {
        public int IdEmployeeJob { get; set; }
        public DateOnly? EffectiveDate { get; set; }
        public decimal? BasePay { get; set; }
        /// <summary>
        /// Day / Month / Week / Hour
        /// </summary>
        public string? BasePayType { get; set; }
        /// <summary>
        /// Works from Mondays to Saturdays: 313 days / Works from Mondays to Friday: 261 days
        /// </summary>
        public int? TotalWorkingDays { get; set; }
        public int? IdEmployee { get; set; }
        public int? IdJobPosition { get; set; }
        public int? IdJobCompensationLevel { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? UpdateBy { get; set; }

        public virtual JobCompensationLevel? IdJobCompensationLevelNavigation { get; set; }
    }
}
