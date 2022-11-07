using System;

namespace HCM.Domain.DTOs
{
    public partial class EmployeeDto
    {
        public int IdEmployee { get; set; }
        public int? IdNum { get; set; }
        public string? IdCardPosition { get; set; }
        public int? DeviceIdNum { get; set; }
        public byte[]? Photo { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? PayoutType { get; set; }
        public string? PaymentMode { get; set; }
        public string? Tags { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Gender { get; set; }
        public string? Email1 { get; set; }
        public string? Email2 { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Mobile1 { get; set; }
        public string? Mobile2 { get; set; }
        public DateOnly? BirthDate { get; set; }
        public DateOnly? EmploymentDate { get; set; }
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