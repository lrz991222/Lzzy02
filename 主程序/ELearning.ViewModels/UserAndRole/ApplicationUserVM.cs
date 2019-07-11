using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELearning.ViewModels.UserAndRole
{
    public class ApplicationUserVM : IEntityViewModel
    {

        public  Guid Id { get; set; }

        [Display(Name = "显示名称")]
        [StringLength(30, ErrorMessage = "显示名称超过了30字符。")]
        [Required(ErrorMessage = "用户名称不能为空值。")]
        public string Name { get; set; }

        [Display(Name = "用户简要描述")]
        [StringLength(100, ErrorMessage = "用户名称超过了100字符。")]
        public  string Description { get; set; }

        [Display(Name = "登录邮件")]
        [Required(ErrorMessage = "电子邮件数据是必须的。")]
        [EmailAddress(ErrorMessage = "请输入合法的电子邮件地址。")]
        public string Email { get; set; }

        [Display(Name = "移动电话")]
        [RegularExpression(@"((^13[0-9]{1}[0-9]{8}|^15[0-9]{1}[0-9]{8}|^14[0-9]{1}[0-9]{8}|^16[0-9]{1}[0-9]{8}|^17[0-9]{1}[0-9]{8}|^18[0-9]{1}[0-9]{8}|^19[0-9]{1}[0-9]{8})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)", ErrorMessage = "电话号码数据不合规！"),
        Required(ErrorMessage = "移动电话号码数据是必须的。"),
        MaxLength(11, ErrorMessage = "电话号码超过11位数！"),
        MinLength(11, ErrorMessage = "电话号码长度不足11位数！")]
        public string Phone { get; set; }

        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "密码是必须的。")]
        [RegularExpression(@"((^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,})$)", ErrorMessage = "密码至少8个字符，至少1个小写字母，一个大写字母，1个数字和1个特殊字符！")]
        public string Password { get; set; }

        [Display(Name = "重复密码")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "密码必须一致")]
        public string PasswordComfirm { get; set; }

        public string AvatarPath { get; set; }   // 头像路径

        public string OrderNumber { get; set; } // 列表时候需要的序号
        public bool IsNew { get; set; }         // 是否是新创建的对象，要特别注意在实际使用时候的赋值

        public bool LockoutEnabled { get; set; } // 用户被禁用状态

        public bool Sex { get; set; }

        [Display(Name = "系统用户组")]
        public List<string> ApplicationRoleItemIdCollection { get; set; }        // 已经加入角色组 Id 集合
        public ApplicationUserVM()
        {
            this.Id = Guid.NewGuid();
            this.IsNew = true;
        }

        }
}
