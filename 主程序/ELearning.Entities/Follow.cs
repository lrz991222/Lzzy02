using ELearning.UserAndRole;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELearning.Entities
{
   public class Follow : IEntityBase
    {
        [Key]
        public Guid Id { get; set; } 

        public ApplicationUser Person { get; set; }

        public ApplicationUser CoverPerson { get; set; }

        public Follow()
        {
            Id= new Guid();
        }
    }
}
