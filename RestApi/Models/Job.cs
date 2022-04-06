using System.Collections.Generic;

namespace RestApi.Models
{
    public class Job
    {
        public Job()
        {
            Employees = new HashSet<Employee>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual  ICollection<Employee> Employees { get; set; }
    }
}