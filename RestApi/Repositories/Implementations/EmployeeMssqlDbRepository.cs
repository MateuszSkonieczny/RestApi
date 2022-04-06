using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestApi.DTO.Responses;
using RestApi.Models;
using RestApi.Repositories.Interfaces;

namespace RestApi.Repositories.Implementations
{
    public class EmployeeMssqlDbRepository: IEmployeeDbRepository
    {
        private readonly EmpContext _context;

        public EmployeeMssqlDbRepository(EmpContext context)
        {
            _context = context;
        }

        public async Task<ICollection<EmployeeResponseDto>> GetEmployeesFromDb()
        {
            var employees = await _context.Employee
                .Include(e => e.IdJobNavigation)
                .Select(e => new EmployeeResponseDto
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Salary = e.Salary,
                    Job = e.IdJobNavigation.Name
                }).ToArrayAsync();

            return employees;
        }

        public async Task<EmployeeDetailsResponseDto> GetEmployeesDetailsFromDb(int id)
        {
            var e = await _context.Employee.SingleOrDefaultAsync(e => e.Id == id);
            if (e is null)
                return null;

            var employee = await _context.Employee
                .Include(e => e.IdJobNavigation)
                .Where(e => e.Id == id)
                .Select(e => new EmployeeDetailsResponseDto
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Salary = e.Salary,
                    Job = e.IdJobNavigation.Name,
                    Employments = _context.Employment
                        .Include(e => e.IdDepartmentNavigation)
                        .Where(r => r.EmpId == id)
                        .Select(r => new EmployeesEmploymentsDto
                        {
                            Department = r.IdDepartmentNavigation.Name,
                            EmploymentDate = r.EmploymentDate,
                            DismissalDate = r.DismissalDate
                        }).ToList()
                }).SingleOrDefaultAsync();

            return employee;
        }
    }
}