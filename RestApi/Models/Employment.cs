using System;

namespace RestApi.Models
{
    public class Employment
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public int DeptId { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime? DismissalDate { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual Department IdDepartmentNavigation { get; set; }
        
    }
}