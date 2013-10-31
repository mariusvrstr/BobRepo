using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBOB.Entities
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }

       // [ForeignKey("Card")]
        public IEnumerable<Card> InterestedCards { get; set; }
       // [ForeignKey("Card")]
        public IEnumerable<Card> CompletedCards { get; set; }
        //[ForeignKey("Challenge")]
        public IEnumerable<Challenge> MyChallenges { get; set; }
    }
}
