using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JBOB.Users;

namespace JBOB.Database.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        // [ForeignKey("Profile")]
        public Profile Profile { get; set; }
        public IEnumerable<UserRoleEnum> Roles { get; set; } 
    }
}
