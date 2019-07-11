using ELearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZebraWeb.Models
{
    public class TravelsNoteVM
    {
        public Guid ID { get; set; }

        public Guid TravelsID { get; set; }

        public virtual Travels Travels { get; set; }

        public string Images { get; set; }

        public string Notos { get; set; }
    }
}
