using ELearning.UserAndRole;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELearning.Entities
{
    //结伴
    public class GoWithMenber
    {
        [Key]
        public Guid Id { get; set; }

        public virtual ApplicationUser Person{ get; set; }//结伴用户

        public virtual GoWith GoWith { get; set; }//所绑定的结伴

        public string Explain { get; set; }//结伴说明

        public GoWithMenber()
        {
            Id = new Guid();
        }
    }
}
