using System.Collections.Generic;
using System.Threading.Tasks;
using RestApi.DTO.Responses;

namespace RestApi.Repositories.Interfaces
{
    public interface IEmployeeDbRepository
    {
        Task<ICollection<EmployeeResponseDto>> GetEmployeesFromDb();

        Task<EmployeeDetailsResponseDto> GetEmployeesDetailsFromDb(int id);


    }
}