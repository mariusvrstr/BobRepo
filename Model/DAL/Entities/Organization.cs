using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JBOB.Organizations;

namespace JBOB.Database.Entities
{
    public class Organization
    {
        [Key]
        public int OrganizationId { get; set; }
        
       // [ForeignKey("User")]
        public IEnumerable<User> Employees { get; set; }

       // [ForeignKey("Department")]
        public IEnumerable<Department> Departments { get; set; } 

        public OrganizationTypeEnum Type { get; set; }
    }
}
