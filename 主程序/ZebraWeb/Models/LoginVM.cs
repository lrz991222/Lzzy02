using ELearning.UserAndRole;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZebraWeb.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "用户名是必须的。")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "密码是必须的。")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }    // 登录成功后返回的路径，缺省返回到入口首页
        public bool RememberMe { get; set; }     // 记住我

        public string Name { get; set; }//姓名


        public string HerdPortrait { get; set; }//头像

        public bool Sex { get; set; }//性别

        public long Phone { get; set; }//电话

        [StringLength(20)]
        public string DisplayName { get; set; }  // 显示名（用于显示中文名）
        [StringLength(100)]
        public string Synopsis { get; set; }//简介

        public bool IsDefaultRole { get; set; }  // 是否是缺省用户组，如果是，则不能在管理台中进行编辑和删除

        public ApplicationRoleTypeEnum ApplicationRoleType { get; set; }  // 角色类型

    }
}
