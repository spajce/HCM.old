using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HCM.Domain.Entities;

namespace HCM.Domain
{
    public partial class HCMDbContext : DbContext
    {
        public HCMDbContext(DbContextOptions<HCMDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AllowanceParticular> AllowanceParticulars { get; set; } = null!;
        public virtual DbSet<AttendanceLog> AttendanceLogs { get; set; } = null!;
        public virtual DbSet<AttendanceLogSource> AttendanceLogSources { get; set; } = null!;
        public virtual DbSet<Bank> Banks { get; set; } = null!;
        public virtual DbSet<CompanyDetail> CompanyDetails { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeAllowance> EmployeeAllowances { get; set; } = null!;
        public virtual DbSet<EmployeeDependent> EmployeeDependents { get; set; } = null!;
        public virtual DbSet<EmployeeDocument> EmployeeDocuments { get; set; } = null!;
        public virtual DbSet<EmployeeDocumentPreset> EmployeeDocumentPresets { get; set; } = null!;
        public virtual DbSet<EmployeeEducational> EmployeeEducationals { get; set; } = null!;
        public virtual DbSet<EmployeeIncentiveLeave> EmployeeIncentiveLeaves { get; set; } = null!;
        public virtual DbSet<EmployeeJob> EmployeeJobs { get; set; } = null!;
        public virtual DbSet<EmployeePayment> EmployeePayments { get; set; } = null!;
        public virtual DbSet<EmployeeReference> EmployeeReferences { get; set; } = null!;
        public virtual DbSet<EmployeeReligion> EmployeeReligions { get; set; } = null!;
        public virtual DbSet<EmployeeSeminar> EmployeeSeminars { get; set; } = null!;
        public virtual DbSet<Holiday> Holidays { get; set; } = null!;
        public virtual DbSet<HolidayPreset> HolidayPresets { get; set; } = null!;
        public virtual DbSet<HolidayType> HolidayTypes { get; set; } = null!;
        public virtual DbSet<IncentiveLeaveType> IncentiveLeaveTypes { get; set; } = null!;
        public virtual DbSet<JobBranch> JobBranches { get; set; } = null!;
        public virtual DbSet<JobCompensationLevel> JobCompensationLevels { get; set; } = null!;
        public virtual DbSet<JobDepartment> JobDepartments { get; set; } = null!;
        public virtual DbSet<JobGatePass> JobGatePasses { get; set; } = null!;
        public virtual DbSet<JobGatePassDetail> JobGatePassDetails { get; set; } = null!;
        public virtual DbSet<JobLeave> JobLeaves { get; set; } = null!;
        public virtual DbSet<JobLeaveDetail> JobLeaveDetails { get; set; } = null!;
        public virtual DbSet<JobLeaveType> JobLeaveTypes { get; set; } = null!;
        public virtual DbSet<JobOvertime> JobOvertimes { get; set; } = null!;
        public virtual DbSet<JobOvertimeDetail> JobOvertimeDetails { get; set; } = null!;
        public virtual DbSet<JobOvertimePreset> JobOvertimePresets { get; set; } = null!;
        public virtual DbSet<JobOvertimeRateDetail> JobOvertimeRateDetails { get; set; } = null!;
        public virtual DbSet<JobOvertimeRule> JobOvertimeRules { get; set; } = null!;
        public virtual DbSet<JobPosition> JobPositions { get; set; } = null!;
        public virtual DbSet<JobPositionParent> JobPositionParents { get; set; } = null!;
        public virtual DbSet<JobTimetable> JobTimetables { get; set; } = null!;
        public virtual DbSet<JobTimetableEmployee> JobTimetableEmployees { get; set; } = null!;
        public virtual DbSet<JobTimetableGroup> JobTimetableGroups { get; set; } = null!;
        public virtual DbSet<JobTimetableType> JobTimetableTypes { get; set; } = null!;
        public virtual DbSet<Pagibig> Pagibigs { get; set; } = null!;
        public virtual DbSet<PagibigDetail> PagibigDetails { get; set; } = null!;
        public virtual DbSet<PaymentParticular> PaymentParticulars { get; set; } = null!;
        public virtual DbSet<PayrollSchedule> PayrollSchedules { get; set; } = null!;
        public virtual DbSet<PayrollScheduleDetail> PayrollScheduleDetails { get; set; } = null!;
        public virtual DbSet<PayslipHistory> PayslipHistories { get; set; } = null!;
        public virtual DbSet<PhilHealth> PhilHealths { get; set; } = null!;
        public virtual DbSet<PhilHealthDetail> PhilHealthDetails { get; set; } = null!;
        public virtual DbSet<Sss> Ssses { get; set; } = null!;
        public virtual DbSet<SssDetail> SssDetails { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<Timetable> Timetables { get; set; } = null!;
        public virtual DbSet<TimetableDetail> TimetableDetails { get; set; } = null!;
        public virtual DbSet<TimetableHoliday> TimetableHolidays { get; set; } = null!;
        public virtual DbSet<WithholdingTax> WithholdingTaxes { get; set; } = null!;
        public virtual DbSet<WithholdingTaxDetail> WithholdingTaxDetails { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<AllowanceParticular>(entity =>
            {
                entity.HasKey(e => e.IdAllowanceParticular)
                    .HasName("PRIMARY");

                entity.ToTable("AllowanceParticular");

                entity.Property(e => e.AccountCode)
                    .HasMaxLength(45)
                    .HasComment("Related to Accounting");

                entity.Property(e => e.AccountType)
                    .HasMaxLength(45)
                    .HasComment("Debit or Credit");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ParticularName)
                    .HasMaxLength(75)
                    .HasComment("Ex. Adjustment / Advance / Benefit / Bonus / Miscellanos / Vacation Pay / Due Charges / and any Loans and Goverment Loans / Allowance");

                entity.Property(e => e.Position).HasComment("Order By");
            });

            modelBuilder.Entity<AttendanceLog>(entity =>
            {
                entity.HasKey(e => e.IdAttendanceLog)
                    .HasName("PRIMARY");

                entity.ToTable("AttendanceLog");

                entity.HasIndex(e => e.IdAttendanceLogSource, "fk_AttendanceLog_AttendanceLogSource1_idx");

                entity.HasIndex(e => e.DeviceIdNum, "ix_DeviceIdNum");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy).HasMaxLength(125);

                entity.Property(e => e.DeviceIdNum).HasComment("Biometric Id Num");

                entity.Property(e => e.DeviceName).HasMaxLength(45);

                entity.Property(e => e.LogDateTime).HasColumnType("datetime");

                entity.Property(e => e.LogStatus).HasMaxLength(45);

                entity.Property(e => e.LogTime).HasColumnType("time");

                entity.Property(e => e.LogType).HasMaxLength(45);

                entity.HasOne(d => d.IdAttendanceLogSourceNavigation)
                    .WithMany(p => p.AttendanceLogs)
                    .HasForeignKey(d => d.IdAttendanceLogSource)
                    .HasConstraintName("fk_AttendanceLog_AttendanceLogSource1");
            });

            modelBuilder.Entity<AttendanceLogSource>(entity =>
            {
                entity.HasKey(e => e.IdAttendanceLogSource)
                    .HasName("PRIMARY");

                entity.ToTable("AttendanceLogSource");

                entity.HasIndex(e => e.AttendanceLogSourceName, "AttendanceLogSourceName_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.AttendanceLogSourceName)
                    .HasMaxLength(45)
                    .HasComment("Generated Name (Device Name) - (Generated Date and Time)");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy).HasMaxLength(125);
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(e => e.IdBank)
                    .HasName("PRIMARY");

                entity.ToTable("Bank");

                entity.Property(e => e.BankName).HasMaxLength(45);

                entity.Property(e => e.Branch).HasMaxLength(45);

                entity.Property(e => e.Code).HasMaxLength(45);
            });

            modelBuilder.Entity<CompanyDetail>(entity =>
            {
                entity.HasKey(e => e.IdCompanyDetails)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdCompanyDetails).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(45);

                entity.Property(e => e.CompanyName).HasMaxLength(45);

                entity.Property(e => e.Logo).HasMaxLength(45);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("PRIMARY");

                entity.ToTable("Employee");

                entity.Property(e => e.Address1).HasColumnType("text");

                entity.Property(e => e.Address2).HasColumnType("text");

                entity.Property(e => e.BankAccountNum).HasMaxLength(45);

                entity.Property(e => e.CivilStatus)
                    .HasMaxLength(45)
                    .HasComment("Single /  Married / Widow / Separated / Annul");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy).HasMaxLength(125);

                entity.Property(e => e.DeviceIdNum).HasComment("Attendance ID / Biometric ID");

                entity.Property(e => e.Email1)
                    .HasMaxLength(256)
                    .HasComment("Company Email");

                entity.Property(e => e.Email2)
                    .HasMaxLength(256)
                    .HasComment("Personal Email");

                entity.Property(e => e.EmergencyContactAddress).HasColumnType("text");

                entity.Property(e => e.EmergencyContactNo).HasMaxLength(256);

                entity.Property(e => e.EmergencyContactPerson).HasMaxLength(75);

                entity.Property(e => e.FirstName).HasMaxLength(25);

                entity.Property(e => e.Gender).HasMaxLength(45);

                entity.Property(e => e.IdCardPosition)
                    .HasMaxLength(75)
                    .HasComment("Custom ID Card Job Position Name");

                entity.Property(e => e.LastName).HasMaxLength(25);

                entity.Property(e => e.MiddleName).HasMaxLength(25);

                entity.Property(e => e.Mobile1)
                    .HasMaxLength(256)
                    .HasComment("Company Mobile");

                entity.Property(e => e.Mobile2)
                    .HasMaxLength(256)
                    .HasComment("Personal Mobile");

                entity.Property(e => e.PaymentMode)
                    .HasMaxLength(45)
                    .HasComment("Hourly(Not Avalaible), Weekly(Not Avalaible) / Monthly / Salary");

                entity.Property(e => e.PayoutType)
                    .HasMaxLength(25)
                    .HasComment("Cash / ATM");

                entity.Property(e => e.Photo).HasColumnType("mediumblob");

                entity.Property(e => e.Tags).HasMaxLength(150);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(125);

                entity.Property(e => e.Username).HasMaxLength(256);
            });

            modelBuilder.Entity<EmployeeAllowance>(entity =>
            {
                entity.HasKey(e => e.IdEmployeeAllowance)
                    .HasName("PRIMARY");

                entity.ToTable("EmployeeAllowance");

                entity.HasIndex(e => e.IdAllowanceParticular, "fk_EmployeeAllowance_AllowanceParticular1_idx");

                entity.Property(e => e.Destination)
                    .HasMaxLength(45)
                    .HasComment("ref to http://support.payrollhero.com/knowledge-base/how-to-set-up-employees-allowances/");

                entity.Property(e => e.Frequency)
                    .HasMaxLength(45)
                    .HasComment("Per Payroll / Monthly /  Per Present Day");

                entity.Property(e => e.VariabilityType)
                    .HasMaxLength(45)
                    .HasComment("refer to http://support.payrollhero.com/knowledge-base/how-to-set-up-employees-allowances/");

                entity.HasOne(d => d.IdAllowanceParticularNavigation)
                    .WithMany(p => p.EmployeeAllowances)
                    .HasForeignKey(d => d.IdAllowanceParticular)
                    .HasConstraintName("fk_EmployeeAllowance_AllowanceParticular1");
            });

            modelBuilder.Entity<EmployeeDependent>(entity =>
            {
                entity.HasKey(e => e.IdEmployeeDependent)
                    .HasName("PRIMARY");

                entity.ToTable("EmployeeDependent");
            });

            modelBuilder.Entity<EmployeeDocument>(entity =>
            {
                entity.HasKey(e => e.IdEmployeeDocument)
                    .HasName("PRIMARY");

                entity.ToTable("EmployeeDocument");

                entity.HasIndex(e => e.IdEmployeeDocumentPreset, "fk_EmployeeDocument_EmployeeDocumentPreset_idx");

                entity.HasIndex(e => e.IdEmployee, "ix_IdEmployee");

                entity.Property(e => e.IdEmployeeDocument).ValueGeneratedNever();

                entity.Property(e => e.Remarks).HasColumnType("text");

                entity.HasOne(d => d.IdEmployeeDocumentPresetNavigation)
                    .WithMany(p => p.EmployeeDocuments)
                    .HasForeignKey(d => d.IdEmployeeDocumentPreset)
                    .HasConstraintName("fk_EmployeeDocument_EmployeeDocumentPreset");
            });

            modelBuilder.Entity<EmployeeDocumentPreset>(entity =>
            {
                entity.HasKey(e => e.IdDocument)
                    .HasName("PRIMARY");

                entity.ToTable("EmployeeDocumentPreset");

                entity.Property(e => e.IdDocument).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(45);

                entity.Property(e => e.DocumentName).HasMaxLength(45);
            });

            modelBuilder.Entity<EmployeeEducational>(entity =>
            {
                entity.HasKey(e => e.IdEmployeeEducational)
                    .HasName("PRIMARY");

                entity.ToTable("EmployeeEducational");

                entity.Property(e => e.IdEmployeeEducational).ValueGeneratedNever();
            });

            modelBuilder.Entity<EmployeeIncentiveLeave>(entity =>
            {
                entity.HasKey(e => e.IdEmployeeIncentiveLeave)
                    .HasName("PRIMARY");

                entity.ToTable("EmployeeIncentiveLeave");

                entity.HasIndex(e => e.IdIncentiveLeaveType, "fk_EmployeeIncentiveLeave_IncentiveLeaveType1_idx");

                entity.HasIndex(e => e.IdEmployee, "ix_IdEmployee");

                entity.Property(e => e.Days).HasComment("Alloted Days");

                entity.HasOne(d => d.IdIncentiveLeaveTypeNavigation)
                    .WithMany(p => p.EmployeeIncentiveLeaves)
                    .HasForeignKey(d => d.IdIncentiveLeaveType)
                    .HasConstraintName("fk_EmployeeIncentiveLeave_IncentiveLeaveType1");
            });

            modelBuilder.Entity<EmployeeJob>(entity =>
            {
                entity.HasKey(e => e.IdEmployeeJob)
                    .HasName("PRIMARY");

                entity.ToTable("EmployeeJob");

                entity.HasIndex(e => e.IdJobCompensationLevel, "fk_EmployeeJob_JobCompensationLevel1_idx");

                entity.HasIndex(e => e.IdEmployee, "ix_IdEmployee");

                entity.Property(e => e.IdEmployeeJob).ValueGeneratedNever();

                entity.Property(e => e.BasePay).HasPrecision(15, 4);

                entity.Property(e => e.BasePayType)
                    .HasMaxLength(45)
                    .HasComment("Day / Month / Week / Hour");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy).HasMaxLength(125);

                entity.Property(e => e.TotalWorkingDays).HasComment("Works from Mondays to Saturdays: 313 days / Works from Mondays to Friday: 261 days");

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(125);

                entity.HasOne(d => d.IdJobCompensationLevelNavigation)
                    .WithMany(p => p.EmployeeJobs)
                    .HasForeignKey(d => d.IdJobCompensationLevel)
                    .HasConstraintName("fk_EmployeeJobCompensationLevel_JobCompensationLevel1");
            });

            modelBuilder.Entity<EmployeePayment>(entity =>
            {
                entity.HasKey(e => e.IdEmployeePayment)
                    .HasName("PRIMARY");

                entity.ToTable("EmployeePayment");

                entity.HasIndex(e => e.DocNum, "DocNum_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdPaymentParticular, "fk_PaymentEmployee_PaymentParticular_idx");

                entity.Property(e => e.AuthStatus).HasMaxLength(45);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy).HasMaxLength(125);

                entity.Property(e => e.IncludeToYearEndPay).HasComment("mostly for Adjustment or Adjustment Salary");

                entity.Property(e => e.PaymentAmount).HasPrecision(15, 4);

                entity.Property(e => e.PaymentTerm)
                    .HasMaxLength(45)
                    .HasComment("Wouldbe as Payment Term (for information only)");

                entity.Property(e => e.PayrollSchedule)
                    .HasMaxLength(45)
                    .HasComment("1st Half / 2nd Half / Every Payroll (devide principal amount in to 2)");

                entity.Property(e => e.PrincipalAmount).HasPrecision(15, 4);

                entity.Property(e => e.Purpose).HasColumnType("text");

                entity.Property(e => e.Remarks).HasColumnType("text");

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(125);

                entity.HasOne(d => d.IdPaymentParticularNavigation)
                    .WithMany(p => p.EmployeePayments)
                    .HasForeignKey(d => d.IdPaymentParticular)
                    .HasConstraintName("fk_EmployeePayment_PaymentParticular1");
            });

            modelBuilder.Entity<EmployeeReference>(entity =>
            {
                entity.HasKey(e => e.IdEmployeeReference)
                    .HasName("PRIMARY");

                entity.ToTable("EmployeeReference");

                entity.Property(e => e.IdEmployeeReference).ValueGeneratedNever();
            });

            modelBuilder.Entity<EmployeeReligion>(entity =>
            {
                entity.HasKey(e => e.IdEmployeeReligion)
                    .HasName("PRIMARY");

                entity.ToTable("EmployeeReligion");

                entity.Property(e => e.IdEmployeeReligion).ValueGeneratedNever();
            });

            modelBuilder.Entity<EmployeeSeminar>(entity =>
            {
                entity.HasKey(e => e.IdEmployeeSeminar)
                    .HasName("PRIMARY");

                entity.ToTable("EmployeeSeminar");

                entity.Property(e => e.IdEmployeeSeminar).ValueGeneratedNever();
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.HasKey(e => e.IdHoliday)
                    .HasName("PRIMARY");

                entity.ToTable("Holiday");

                entity.HasIndex(e => new { e.HolidayDate, e.IdHolidayPreset }, "HolidayDate_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdHolidayPreset, "fk_Holiday_HolidayPreset1_idx");

                entity.HasIndex(e => e.IdHolidayType, "fk_Holiday_HolidayType1_idx");

                entity.HasOne(d => d.IdHolidayPresetNavigation)
                    .WithMany(p => p.Holidays)
                    .HasForeignKey(d => d.IdHolidayPreset)
                    .HasConstraintName("fk_Holiday_HolidayPreset1");

                entity.HasOne(d => d.IdHolidayTypeNavigation)
                    .WithMany(p => p.Holidays)
                    .HasForeignKey(d => d.IdHolidayType)
                    .HasConstraintName("fk_Holiday_HolidayType1");
            });

            modelBuilder.Entity<HolidayPreset>(entity =>
            {
                entity.HasKey(e => e.IdHolidayPreset)
                    .HasName("PRIMARY");

                entity.ToTable("HolidayPreset");

                entity.Property(e => e.IdHolidayPreset).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(45);

                entity.Property(e => e.HolidayPresetName).HasMaxLength(45);
            });

            modelBuilder.Entity<HolidayType>(entity =>
            {
                entity.HasKey(e => e.IdHolidayType)
                    .HasName("PRIMARY");

                entity.ToTable("HolidayType");

                entity.Property(e => e.IdHolidayType).ValueGeneratedNever();

                entity.Property(e => e.HolidayTypeName).HasMaxLength(45);
            });

            modelBuilder.Entity<IncentiveLeaveType>(entity =>
            {
                entity.HasKey(e => e.IdIncentiveLeaveType)
                    .HasName("PRIMARY");

                entity.ToTable("IncentiveLeaveType");

                entity.HasIndex(e => e.IncentiveLeaveTypeName, "IncentiveLeaveTypeName_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Days).HasComment("Default Alloted Days");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.IncentiveLeaveTypeName).HasMaxLength(75);
            });

            modelBuilder.Entity<JobBranch>(entity =>
            {
                entity.HasKey(e => e.IdJobBranch)
                    .HasName("PRIMARY");

                entity.ToTable("JobBranch");

                entity.HasIndex(e => e.JobBranchName, "JobBranchName_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdJobBranch).ValueGeneratedNever();

                entity.Property(e => e.JobBranchName).HasMaxLength(45);
            });

            modelBuilder.Entity<JobCompensationLevel>(entity =>
            {
                entity.HasKey(e => e.IdJobCompensationLevel)
                    .HasName("PRIMARY");

                entity.ToTable("JobCompensationLevel");

                entity.HasIndex(e => e.IdJobPosition, "fk_JobCompensationLevel_JobPosition1_idx");

                entity.Property(e => e.BasePay).HasPrecision(15, 4);

                entity.Property(e => e.BasePayType)
                    .HasMaxLength(45)
                    .HasComment("Monthly, Daily / Weekly and Hourly still on research");

                entity.Property(e => e.LevelName).HasMaxLength(45);

                entity.Property(e => e.TotalWorkingDays).HasComment("Works from Mondays to Saturdays: 313 days / Works from Mondays to Friday: 261 days");

                entity.HasOne(d => d.IdJobPositionNavigation)
                    .WithMany(p => p.JobCompensationLevels)
                    .HasForeignKey(d => d.IdJobPosition)
                    .HasConstraintName("fk_CompensationLevel_JobPosition1");
            });

            modelBuilder.Entity<JobDepartment>(entity =>
            {
                entity.HasKey(e => e.IdJobDepartment)
                    .HasName("PRIMARY");

                entity.ToTable("JobDepartment");

                entity.HasIndex(e => e.JobDepartmentName, "JobDepartmentName_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdJobDepartment).ValueGeneratedNever();

                entity.Property(e => e.JobDepartmentName).HasMaxLength(45);
            });

            modelBuilder.Entity<JobGatePass>(entity =>
            {
                entity.HasKey(e => e.IdJobGatePass)
                    .HasName("PRIMARY");

                entity.ToTable("JobGatePass");

                entity.HasIndex(e => e.DocNum, "DocNum_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdEmployee, "ix_IdEmployee");

                entity.Property(e => e.AuthStatus).HasMaxLength(45);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy).HasMaxLength(125);

                entity.Property(e => e.Equipements).HasColumnType("text");

                entity.Property(e => e.Remarks).HasColumnType("text");

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(125);
            });

            modelBuilder.Entity<JobGatePassDetail>(entity =>
            {
                entity.HasKey(e => e.IdJobGatePassDetail)
                    .HasName("PRIMARY");

                entity.ToTable("JobGatePassDetail");

                entity.HasIndex(e => e.IdJobGatePass, "fk_JobGatePassDetail_JobGatePass1_idx");

                entity.HasIndex(e => e.IdAttendanceLogEnd, "ix_IdAttendanceLogEnd");

                entity.HasIndex(e => e.IdAttendanceLogStart, "ix_IdAttendanceLogStart");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy).HasMaxLength(125);

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasComment("Time Return");

                entity.Property(e => e.Particulars).HasMaxLength(500);

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasComment("Time Out");

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(125);

                entity.HasOne(d => d.IdJobGatePassNavigation)
                    .WithMany(p => p.JobGatePassDetails)
                    .HasForeignKey(d => d.IdJobGatePass)
                    .HasConstraintName("fk_JobGatePassDetail_JobGatePass1");
            });

            modelBuilder.Entity<JobLeave>(entity =>
            {
                entity.HasKey(e => e.IdJobLeave)
                    .HasName("PRIMARY");

                entity.ToTable("JobLeave");

                entity.HasIndex(e => e.DocNum, "DocNum_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdJobLeaveType, "fk_JobLeave_JobLeaveType1_idx");

                entity.HasIndex(e => e.IdEmployee, "ix_IdEmployee");

                entity.HasIndex(e => e.IdEmployeeIncentiveLeave, "ix_IdEmployeeIncentiveLeave");

                entity.Property(e => e.IdJobLeave).ValueGeneratedNever();

                entity.Property(e => e.AuthStatus).HasMaxLength(45);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy).HasMaxLength(125);

                entity.Property(e => e.Reason).HasColumnType("text");

                entity.Property(e => e.Remarks).HasColumnType("text");

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(125);

                entity.HasOne(d => d.IdJobLeaveTypeNavigation)
                    .WithMany(p => p.JobLeaves)
                    .HasForeignKey(d => d.IdJobLeaveType)
                    .HasConstraintName("fk_JobLeave_JobLeaveType1");
            });

            modelBuilder.Entity<JobLeaveDetail>(entity =>
            {
                entity.HasKey(e => e.IdJobLeaveDetail)
                    .HasName("PRIMARY");

                entity.ToTable("JobLeaveDetail");

                entity.HasIndex(e => e.IdJobLeave, "fk_JobLeaveDetail_JobLeave1_idx");

                entity.HasIndex(e => e.IdJobTimetable, "ix_IdJobTimetable");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy).HasMaxLength(125);

                entity.Property(e => e.LeaveDayType)
                    .HasMaxLength(45)
                    .HasComment("AM - Half Day / PM - Half Day / Whole Day");

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(125);

                entity.HasOne(d => d.IdJobLeaveNavigation)
                    .WithMany(p => p.JobLeaveDetails)
                    .HasForeignKey(d => d.IdJobLeave)
                    .HasConstraintName("fk_JobLeaveDetail_JobLeave1");
            });

            modelBuilder.Entity<JobLeaveType>(entity =>
            {
                entity.HasKey(e => e.IdJobLeaveType)
                    .HasName("PRIMARY");

                entity.ToTable("JobLeaveType");

                entity.HasIndex(e => e.JobLeaveTypeName, "JobLeaveTypeName_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.JobLeaveTypeName).HasMaxLength(75);
            });

            modelBuilder.Entity<JobOvertime>(entity =>
            {
                entity.HasKey(e => e.IdJobOvertime)
                    .HasName("PRIMARY");

                entity.ToTable("JobOvertime");

                entity.HasIndex(e => e.DocNum, "DocNum_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdEmployee, "ix_IdEmployee");

                entity.Property(e => e.AuthStatus).HasMaxLength(45);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy).HasMaxLength(125);

                entity.Property(e => e.PaymentDate).HasComment("Custom Payment Date: If has date, the date will be follow when to payment of overtime, note: the date must be between of payroll schedule dates");

                entity.Property(e => e.Remarks).HasColumnType("text");

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(125);
            });

            modelBuilder.Entity<JobOvertimeDetail>(entity =>
            {
                entity.HasKey(e => e.IdJobOvertimeDetail)
                    .HasName("PRIMARY");

                entity.ToTable("JobOvertimeDetail");

                entity.HasIndex(e => e.IdJobOvertime, "fk_JobOvertimeDetail_JobOvertime1_idx");

                entity.Property(e => e.Accomplishments).HasColumnType("text");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy).HasMaxLength(125);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(125);

                entity.HasOne(d => d.IdJobOvertimeNavigation)
                    .WithMany(p => p.JobOvertimeDetails)
                    .HasForeignKey(d => d.IdJobOvertime)
                    .HasConstraintName("fk_JobOvertimeDetail_JobOvertime1");
            });

            modelBuilder.Entity<JobOvertimePreset>(entity =>
            {
                entity.HasKey(e => e.IdJobOvertimePreset)
                    .HasName("PRIMARY");

                entity.ToTable("JobOvertimePreset");

                entity.HasIndex(e => e.JobOvertimePresetName, "JobOvertimeRuleName_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdJobOvertimePreset).ValueGeneratedNever();

                entity.Property(e => e.JobOvertimePresetName).HasMaxLength(45);
            });

            modelBuilder.Entity<JobOvertimeRateDetail>(entity =>
            {
                entity.HasKey(e => e.IdJobOvertimeRateDetail)
                    .HasName("PRIMARY");

                entity.ToTable("JobOvertimeRateDetail");

                entity.HasIndex(e => e.IdJobOvertimePreset, "fk_JobOvertimeRateDetail_JobOvertimeRate_idx");

                entity.Property(e => e.IdJobOvertimeRateDetail).ValueGeneratedNever();

                entity.Property(e => e.Code).HasMaxLength(45);

                entity.Property(e => e.OvertimeRateName).HasMaxLength(75);

                entity.HasOne(d => d.IdJobOvertimePresetNavigation)
                    .WithMany(p => p.JobOvertimeRateDetails)
                    .HasForeignKey(d => d.IdJobOvertimePreset)
                    .HasConstraintName("fk_JobOvertimeRuleDetail_JobOvertimeRule");
            });

            modelBuilder.Entity<JobOvertimeRule>(entity =>
            {
                entity.HasKey(e => e.IdJobOvertimeRules)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<JobPosition>(entity =>
            {
                entity.HasKey(e => e.IdJobPosition)
                    .HasName("PRIMARY");

                entity.ToTable("JobPosition");

                entity.HasIndex(e => e.JobPositionName, "JobPositionName_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdJobPosition).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.JobPositionName).HasMaxLength(45);
            });

            modelBuilder.Entity<JobPositionParent>(entity =>
            {
                entity.HasKey(e => e.IdJobPositionParent)
                    .HasName("PRIMARY");

                entity.ToTable("JobPositionParent");

                entity.HasIndex(e => e.IdJobPosition, "fk_JobPositionParent_JobPosition1_idx");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.HasOne(d => d.IdJobPositionNavigation)
                    .WithMany(p => p.JobPositionParents)
                    .HasForeignKey(d => d.IdJobPosition)
                    .HasConstraintName("fk_JobPositionParent_JobPosition1");
            });

            modelBuilder.Entity<JobTimetable>(entity =>
            {
                entity.HasKey(e => e.IdJobTimetable)
                    .HasName("PRIMARY");

                entity.ToTable("JobTimetable");

                entity.HasIndex(e => e.IdJobTimetableGroup, "fk_JobTimetable_JobTimetableGroup1_idx");

                entity.HasIndex(e => e.IdTimetable, "fk_JobTimetable_Timetable1_idx");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy).HasMaxLength(125);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(125);

                entity.HasOne(d => d.IdJobTimetableGroupNavigation)
                    .WithMany(p => p.JobTimetables)
                    .HasForeignKey(d => d.IdJobTimetableGroup)
                    .HasConstraintName("fk_JobTimetable_JobTimetableGroup1");

                entity.HasOne(d => d.IdTimetableNavigation)
                    .WithMany(p => p.JobTimetables)
                    .HasForeignKey(d => d.IdTimetable)
                    .HasConstraintName("fk_JobTimetable_Timetable1");
            });

            modelBuilder.Entity<JobTimetableEmployee>(entity =>
            {
                entity.HasKey(e => e.IdJobTimetableEmployee)
                    .HasName("PRIMARY");

                entity.ToTable("JobTimetableEmployee");

                entity.HasIndex(e => e.IdJobTimetableGroup, "fk_JobTimetableEmployee_JobTimetableGroup1_idx");

                entity.Property(e => e.AuthStatus).HasMaxLength(45);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy).HasMaxLength(125);

                entity.HasOne(d => d.IdJobTimetableGroupNavigation)
                    .WithMany(p => p.JobTimetableEmployees)
                    .HasForeignKey(d => d.IdJobTimetableGroup)
                    .HasConstraintName("fk_JobTimetableEmployee_JobTimetableGroup1");
            });

            modelBuilder.Entity<JobTimetableGroup>(entity =>
            {
                entity.HasKey(e => e.IdJobTimetableGroup)
                    .HasName("PRIMARY");

                entity.ToTable("JobTimetableGroup");

                entity.Property(e => e.JobTimetableGroupName).HasMaxLength(45);
            });

            modelBuilder.Entity<JobTimetableType>(entity =>
            {
                entity.HasKey(e => e.IdJobTimetableType)
                    .HasName("PRIMARY");

                entity.ToTable("JobTimetableType");

                entity.Property(e => e.IdJobTimetableType).ValueGeneratedNever();
            });

            modelBuilder.Entity<Pagibig>(entity =>
            {
                entity.HasKey(e => e.IdPagibig)
                    .HasName("PRIMARY");

                entity.ToTable("Pagibig");

                entity.Property(e => e.IdPagibig).ValueGeneratedNever();

                entity.Property(e => e.Active).HasMaxLength(45);

                entity.Property(e => e.PagibigName).HasMaxLength(45);
            });

            modelBuilder.Entity<PagibigDetail>(entity =>
            {
                entity.HasKey(e => e.IdPagibigDetail)
                    .HasName("PRIMARY");

                entity.ToTable("PagibigDetail");

                entity.HasIndex(e => e.IdPagibig, "fk_PagibigDetail_Pagibig1_idx");

                entity.Property(e => e.IdPagibigDetail).ValueGeneratedNever();

                entity.HasOne(d => d.IdPagibigNavigation)
                    .WithMany(p => p.PagibigDetails)
                    .HasForeignKey(d => d.IdPagibig)
                    .HasConstraintName("fk_PagibigDetail_Pagibig1");
            });

            modelBuilder.Entity<PaymentParticular>(entity =>
            {
                entity.HasKey(e => e.IdPaymentParticular)
                    .HasName("PRIMARY");

                entity.ToTable("PaymentParticular");

                entity.HasIndex(e => e.ParticularName, "ParticularName_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.AccountCode)
                    .HasMaxLength(45)
                    .HasComment("Related to Accounting");

                entity.Property(e => e.AccountType)
                    .HasMaxLength(45)
                    .HasComment("Debit or Credit");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ParticularName)
                    .HasMaxLength(75)
                    .HasComment("Ex. Adjustment / Advance / Benefit / Bonus / Miscellanos / Vacation Pay / Due Charges / and any Loans and Goverment Loans / Allowance");

                entity.Property(e => e.Position).HasComment("Order By");
            });

            modelBuilder.Entity<PayrollSchedule>(entity =>
            {
                entity.HasKey(e => e.IdPayrollSchedule)
                    .HasName("PRIMARY");

                entity.ToTable("PayrollSchedule");

                entity.Property(e => e.PayrollScheduleName)
                    .HasMaxLength(45)
                    .HasComment("Year Name or other names");
            });

            modelBuilder.Entity<PayrollScheduleDetail>(entity =>
            {
                entity.HasKey(e => e.IdPayrollScheduleDetail)
                    .HasName("PRIMARY");

                entity.ToTable("PayrollScheduleDetail");

                entity.HasIndex(e => e.IdPayrollSchedule, "fk_PayrollScheduleDetail_PayrollSchedule1_idx");

                entity.Property(e => e.PayrollSchedule)
                    .HasMaxLength(45)
                    .HasComment("1st Half / 2nd Half and so on");

                entity.HasOne(d => d.IdPayrollScheduleNavigation)
                    .WithMany(p => p.PayrollScheduleDetails)
                    .HasForeignKey(d => d.IdPayrollSchedule)
                    .HasConstraintName("fk_PayrollScheduleDetail_PayrollSchedule1");
            });

            modelBuilder.Entity<PayslipHistory>(entity =>
            {
                entity.HasKey(e => e.IdPayslipHistory)
                    .HasName("PRIMARY");

                entity.ToTable("PayslipHistory");
            });

            modelBuilder.Entity<PhilHealth>(entity =>
            {
                entity.HasKey(e => e.IdPhilHealth)
                    .HasName("PRIMARY");

                entity.ToTable("PhilHealth");

                entity.Property(e => e.PhilHealthName).HasMaxLength(45);
            });

            modelBuilder.Entity<PhilHealthDetail>(entity =>
            {
                entity.HasKey(e => e.IdPhilHealthDetail)
                    .HasName("PRIMARY");

                entity.ToTable("PhilHealthDetail");

                entity.HasIndex(e => e.IdPhilHealth, "fk_PhilHealthContributionDetail_PhilHealthContribution1_idx");

                entity.HasOne(d => d.IdPhilHealthNavigation)
                    .WithMany(p => p.PhilHealthDetails)
                    .HasForeignKey(d => d.IdPhilHealth)
                    .HasConstraintName("fk_PhilHealthContributionDetail_PhilHealthContribution1");
            });

            modelBuilder.Entity<Sss>(entity =>
            {
                entity.HasKey(e => e.IdSss)
                    .HasName("PRIMARY");

                entity.ToTable("Sss");

                entity.HasIndex(e => e.SssName, "SssName_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdSss).ValueGeneratedNever();

                entity.Property(e => e.SssName).HasMaxLength(45);
            });

            modelBuilder.Entity<SssDetail>(entity =>
            {
                entity.HasKey(e => e.IdSssDetail)
                    .HasName("PRIMARY");

                entity.ToTable("SssDetail");

                entity.HasIndex(e => e.IdSssContribution, "fk_SssContributionDetail_SssContribution1_idx");

                entity.Property(e => e.IdSssDetail).ValueGeneratedNever();

                entity.HasOne(d => d.IdSssContributionNavigation)
                    .WithMany(p => p.SssDetails)
                    .HasForeignKey(d => d.IdSssContribution)
                    .HasConstraintName("fk_SssContributionDetail_SssContribution1");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => e.IdTag)
                    .HasName("PRIMARY");

                entity.ToTable("Tag");

                entity.Property(e => e.IdTag).ValueGeneratedNever();

                entity.Property(e => e.TagName).HasMaxLength(45);

                entity.Property(e => e.TagType)
                    .HasMaxLength(45)
                    .HasComment("Employee");
            });

            modelBuilder.Entity<Timetable>(entity =>
            {
                entity.HasKey(e => e.IdTimetable)
                    .HasName("PRIMARY");

                entity.ToTable("Timetable");

                entity.HasIndex(e => e.TimetableName, "TimetableName_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdTimetable).ValueGeneratedNever();

                entity.Property(e => e.ShiftType)
                    .HasMaxLength(45)
                    .HasComment("Day Shift or Night Shift and so on");

                entity.Property(e => e.TimetableName).HasMaxLength(45);
            });

            modelBuilder.Entity<TimetableDetail>(entity =>
            {
                entity.HasKey(e => e.IdTimetableDetail)
                    .HasName("PRIMARY");

                entity.ToTable("TimetableDetail");

                entity.HasIndex(e => e.IdTimetable, "fk_TimetableDetail_Timetable1_idx");

                entity.Property(e => e.IdTimetableDetail).ValueGeneratedNever();

                entity.Property(e => e.DayOfWeekName).HasMaxLength(45);

                entity.Property(e => e.PunchInAm).HasColumnType("datetime");

                entity.Property(e => e.PunchInAmIntervalEnd).HasColumnType("datetime");

                entity.Property(e => e.PunchInAmIntervalStart).HasColumnType("datetime");

                entity.Property(e => e.PunchInPm).HasColumnType("datetime");

                entity.Property(e => e.PunchInPmIntervalEnd).HasColumnType("datetime");

                entity.Property(e => e.PunchInPmIntervalStart).HasColumnType("datetime");

                entity.Property(e => e.PunchOutAm).HasColumnType("datetime");

                entity.Property(e => e.PunchOutAmIntervalEnd).HasColumnType("datetime");

                entity.Property(e => e.PunchOutAmIntervalStart).HasColumnType("datetime");

                entity.Property(e => e.PunchOutPm).HasColumnType("datetime");

                entity.Property(e => e.PunchOutPmIntervalEnd).HasColumnType("datetime");

                entity.Property(e => e.PunchOutPmIntervalStart).HasColumnType("datetime");

                entity.Property(e => e.ShiftIntervalEnd).HasColumnType("datetime");

                entity.Property(e => e.ShiftIntervalStart).HasColumnType("datetime");

                entity.HasOne(d => d.IdTimetableNavigation)
                    .WithMany(p => p.TimetableDetails)
                    .HasForeignKey(d => d.IdTimetable)
                    .HasConstraintName("fk_TimetableDetail_Timetable1");
            });

            modelBuilder.Entity<TimetableHoliday>(entity =>
            {
                entity.HasKey(e => e.IdTimetableHoliday)
                    .HasName("PRIMARY");

                entity.ToTable("TimetableHoliday");

                entity.HasIndex(e => e.IdHolidayPreset, "fk_TimetableHoliday_HolidayPreset1_idx");

                entity.HasIndex(e => e.IdTimetable, "fk_TimetableHoliday_Timetable1_idx");

                entity.Property(e => e.IdTimetableHoliday).ValueGeneratedNever();

                entity.HasOne(d => d.IdHolidayPresetNavigation)
                    .WithMany(p => p.TimetableHolidays)
                    .HasForeignKey(d => d.IdHolidayPreset)
                    .HasConstraintName("fk_TimetableHoliday_HolidayPreset1");

                entity.HasOne(d => d.IdTimetableNavigation)
                    .WithMany(p => p.TimetableHolidays)
                    .HasForeignKey(d => d.IdTimetable)
                    .HasConstraintName("fk_TimetableHoliday_Timetable1");
            });

            modelBuilder.Entity<WithholdingTax>(entity =>
            {
                entity.HasKey(e => e.IdWithholdingTax)
                    .HasName("PRIMARY");

                entity.ToTable("WithholdingTax");

                entity.HasIndex(e => e.WithholdingTaxName, "WithholdingTaxName_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdWithholdingTax).ValueGeneratedNever();

                entity.Property(e => e.WithholdingTaxName).HasMaxLength(45);
            });

            modelBuilder.Entity<WithholdingTaxDetail>(entity =>
            {
                entity.HasKey(e => e.IdWithholdingTaxDetail)
                    .HasName("PRIMARY");

                entity.ToTable("WithholdingTaxDetail");

                entity.HasIndex(e => e.IdWithholdingTax, "fk_WithholdingTaxDetail_WithholdingTax1_idx");

                entity.Property(e => e.IdWithholdingTaxDetail).ValueGeneratedNever();

                entity.HasOne(d => d.IdWithholdingTaxNavigation)
                    .WithMany(p => p.WithholdingTaxDetails)
                    .HasForeignKey(d => d.IdWithholdingTax)
                    .HasConstraintName("fk_WithholdingTaxDetail_WithholdingTax1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
