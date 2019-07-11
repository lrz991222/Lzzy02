using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZebraWeb.Models
{
    public class LabelVM
    {
        public Guid Id { get; set; }

        [Display(Name = "标签名称")]
        [StringLength(8, ErrorMessage = "你输入的数据超出限制16个字符的长度。")]
        [Required(ErrorMessage = "标签名称不能为空值。")]
        public string LabelName { get; set; }

         
    }
}
