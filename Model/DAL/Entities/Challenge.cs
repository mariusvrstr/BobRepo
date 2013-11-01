using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBOB.Database.Entities
{
    public class Challenge
    {
        [Key]
        public int ChallengeId { get; set; }
        public string Description { get; set; }

        // [ForeignKey("Organization")]
        public Department TargetOrganization { get; set; }

        // [ForeignKey("Department")]
        public IEnumerable<Department> TargetDepartment { get; set; }

        // [ForeignKey("User")]
        public IEnumerable<User> TargetUsers { get; set; }
    }
}
