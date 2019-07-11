using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELearning.Entities
{
    //主题
    public class Theme : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }

        public string themeName { get; set; }


        public Theme()
        {
            Id = new Guid();
        }
    }
}
