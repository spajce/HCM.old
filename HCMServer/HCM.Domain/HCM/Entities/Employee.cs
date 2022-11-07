using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class Employee
    {
        public int IdEmployee { get; set; }
        public int? IdNum { get; set; }
        /// <summary>
        /// Custom ID Card Job Position Name
        /// </summary>
        public string? IdCardPosition { get; set; }
        /// <summary>
        /// Attendance ID / Biometric ID
        /// </summary>
        public int? DeviceIdNum { get; set; }
        public byte[]? Photo { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        /// <summary>
        /// Cash / ATM
        /// </summary>
        public string? PayoutType { get; set; }
        /// <summary>
        /// Hourly(Not Avalaible), Weekly(Not Avalaible) / Monthly / Salary
        /// </summary>
        public string? PaymentMode { get; set; }
        public string? Tags { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Gender { get; set; }
        /// <summary>
        /// Company Email
        /// </summary>
        public string? Email1 { get; set; }
        /// <summary>
        /// Personal Email
        /// </summary>
        public string? Email2 { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        /// <summary>
        /// Company Mobile
        /// </summary>
        public string? Mobile1 { get; set; }
        /// <summary>
        /// Personal Mobile
        /// </summary>
        public string? Mobile2 { get; set; }
        public DateOnly? BirthDate { get; set; }
        public DateOnly? EmploymentDate { get; set; }
        /// <summary>
        /// Single /  Married / Widow / Separated / Annul
        /// </summary>
        public string? CivilStatus { get; set; }
        public string? EmergencyContactPerson { get; set; }
        public string? EmergencyContactAddress { get; set; }
        public string? EmergencyContactNo { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? UpdateBy { get; set; }
        public string? BankAccountNum { get; set; }
        public int? IdBank { get; set; }
        public int? IdEmployeeType { get; set; }
        public int? IdJobPosition { get; set; }
        public int? IdJobDepartment { get; set; }
        public int? IdJobLocation { get; set; }
    }
}
