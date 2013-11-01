using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBOB.Database.Entities
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public IEnumerable<int> ActivityOptions { get; set; }
        public int Weight { get; set; }
       // public string MetaData { get; set; }
    }
}
