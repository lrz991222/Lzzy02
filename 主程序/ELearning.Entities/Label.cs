using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELearning.Entities
{
    //标签
   public class Label : IEntityBase
    {
        [Key]

        public Guid Id  { get; set; }

        public string LabelName { get; set; }

      
        public Label()
        {
            Id = new Guid();
        }
    }
}
