namespace HCM.Domain.DTOs
{
    public partial class JobDepartmentDto
    {
        public int IdJobDepartment { get; set; }
        public string? JobDepartmentName { get; set; }
        public int? IdEmployeeHead { get; set; }
    }
}