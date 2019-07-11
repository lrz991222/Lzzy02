using ELearning.UserAndRole;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELearning.ViewModels.UserAndRole
{
    public class ApplicationRoleVM : IEntityViewModel
    {
        public Guid Id { get  ; set  ; }

        public string OrderNumber { get; set; }

        public bool IsNew { get; set; }

        [Display(Name = "用户组名称")]
        [StringLength(100, ErrorMessage = "用户组名称超过了20字符。")]
        [Required(ErrorMessage = "用户组名称不能为空值。")]
        public string Name { get; set; }

        [Display(Name = "用户组简要描述")]
        [StringLength(500, ErrorMessage = "用户组名称超过了100字符。")]
        public string Description { get; set; }
        

        [Display(Name = "用户组类型")]
        [Required(ErrorMessage = "用户组类型是必须选择的。")]
        public ApplicationRoleTypeEnum ApplicationRoleType { get; set; }
        public int UserAmount { get; set; }

        public string ApplicationRoleTypeName { get; set; }
        

        public ApplicationRoleVM()
        {
            this.Id = Guid.NewGuid();
            this.IsNew = true;
        }
    }
}
