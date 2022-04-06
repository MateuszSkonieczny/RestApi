using System.Collections.Generic;

namespace RestApi.Models
{
    public class Employee
    {
        public Employee()
        {
            Employments = new HashSet<Employment>();
        }
        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public int IdJob { get; set; }
        
        public virtual Job IdJobNavigation { get; set; }
        public virtual ICollection<Employment> Employments { get; set; }
    }
}