using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestApi.DTO.Requests;
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

        public async Task<ICollection<EmployeeResponseDto>> GetEmployeesFromDbAsync()
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

        public async Task<EmployeeDetailsResponseDto> GetEmployeesDetailsFromDbAsync(int id)
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

        public async Task<bool> AddEmployeeToDbAsync(EmployeeRequestDto empDto)
        {
            var r = await _context.AddAsync(new Employee
            {
                FirstName = empDto.FirstName, 
                LastName = empDto.LastName, 
                Salary = empDto.Salary, 
                IdJob = empDto.IdJob
            });

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateEmployeeFromDb(EmployeeRequestDto empDto, int id)
        {
            var emp = await _context.Employee.SingleOrDefaultAsync(e => e.Id == id);
            if (emp is null)
                return false;

            emp.FirstName = empDto.FirstName;
            emp.LastName = empDto.LastName;
            emp.Salary = empDto.Salary;
            emp.IdJob = empDto.IdJob;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteEmployeeFromDb(int id)
        {
            var employments = await _context.Employment.Where(e => e.Id == id).ToListAsync();
            _context.RemoveRange(employments);

            var employee = await _context.Employee.Where(e => e.Id == id).SingleOrDefaultAsync();
            _context.Remove(employee);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}