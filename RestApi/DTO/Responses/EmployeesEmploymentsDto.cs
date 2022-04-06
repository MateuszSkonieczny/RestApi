using System;

namespace RestApi.DTO.Responses
{
    public class EmployeesEmploymentsDto
    {
        public string Department { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime? DismissalDate { get; set; }
    }
}