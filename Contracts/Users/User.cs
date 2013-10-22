using System.Collections.Generic;

namespace JBOB.Users
{
    public class User
    {
        public int UserId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public IEnumerable<UserRoleEnum> Roles { get; set; }

        public override string ToString()
        {
            return string.Format("User: {0}, Surename: {2} ({2})", this.Name, this.Surname, this.Login);
        }
    }
}
