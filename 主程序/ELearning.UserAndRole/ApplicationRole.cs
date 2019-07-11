using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace ELearning.UserAndRole
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        [StringLength(20)]
        public string DisplayName { get; set; }  // 显示名（用于显示中文名）
        [StringLength(100)]
        public string Synopsis { get; set; }//简介

        public bool IsDefaultRole { get; set; }  // 是否是缺省用户组，如果是，则不能在管理台中进行编辑和删除

        public ApplicationRoleTypeEnum ApplicationRoleType { get; set; }  // 角色类型

        public ApplicationRole() : base()
        {
            this.Id = Guid.NewGuid();
        }
        public ApplicationRole(string roleName) : base(roleName)
        {
            this.Id = Guid.NewGuid();
            this.Name = roleName;
        }
    }
}
