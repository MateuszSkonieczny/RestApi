using System.Collections.Generic;
using System.Threading.Tasks;
using RestApi.DTO.Requests;
using RestApi.DTO.Responses;

namespace RestApi.Repositories.Interfaces
{
    public interface IEmployeeDbRepository
    {
        Task<ICollection<EmployeeResponseDto>> GetEmployeesFromDbAsync();

        Task<EmployeeDetailsResponseDto> GetEmployeesDetailsFromDbAsync(int id);

        Task<bool> AddEmployeeToDbAsync(EmployeeRequestDto employeeRequestDto);

        Task<bool> UpdateEmployeeFromDb(EmployeeRequestDto employeeRequestDto, int id);

        Task<bool> DeleteEmployeeFromDb(int id);





    }
}