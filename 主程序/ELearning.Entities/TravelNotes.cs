using System;
using System.Collections.Generic;
using System.Text;

namespace ELearning.Entities
{
   public class TravelNotes
    {

        public Guid ID { get; set; }

        public Guid TravelsID { get; set; }
      
        public virtual Travels Travels { get; set; }

        public string Images { get; set; }

        public string Notos { get; set; }
    }
}
