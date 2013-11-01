using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JBOB.Cards;

namespace JBOB.Entities
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CardCategoryEnum Category { get; set; }
        public IEnumerable<ActivityTypeEnum> ActivityOptions { get; set; }
        public int Weight { get; set; }
    }
}
