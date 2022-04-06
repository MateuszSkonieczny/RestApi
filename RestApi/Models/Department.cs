using System.Collections.Generic;

namespace RestApi.Models
{
    public class Department
    {
        public Department()
        {
            Employments = new HashSet<Employment>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Employment> Employments { get; set; }
    }
}