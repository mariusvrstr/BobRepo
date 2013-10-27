using System.Collections.Generic;
using JBOB.Common;
using JBOB.Users;

namespace JBOB.Models
{
    public class AboutViewModel : ViewModelBase
    {
        public IEnumerable<User> Users { get; set; }

        public string Title { get; set; }
    }
}