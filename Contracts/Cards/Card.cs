using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBOB.Cards
{
    public class Card
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CardCategoryEnum Category { get; set; }
        public IEnumerable<ActivityTypeEnum> ActivityOptions { get; set; }
    }
}
