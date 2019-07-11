using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELearning.UserAndRole
{
    public class ApplicationUser : IdentityUser<Guid>
    { 
        [StringLength(30)]
        public string Name { get; set; }//姓名
  

        public string HerdPortrait { get; set; }//头像

        public bool Sex { get; set; }//性别

        public long Phone { get; set; }//电话

        public string Synopsis { get; set; }//简介

        public ApplicationUser() : base()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
