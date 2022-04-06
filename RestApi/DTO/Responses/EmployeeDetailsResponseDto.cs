using System.Collections.Generic;

namespace RestApi.DTO.Responses
{
    public class EmployeeDetailsResponseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public string Job { get; set; }
        public List<EmployeesEmploymentsDto> Employments { get; set; }
    }
}