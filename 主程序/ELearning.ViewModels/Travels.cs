
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELearning.ViewModels
{
    //游记
    public class Travels
    {
        public Guid TravelsID { get; set; }//游记ID
        [Required(ErrorMessage = "游记标题不能为空值。")]
        [Display(Name = "游记标题")]
        [StringLength(100, ErrorMessage = "你输入的数据超出限制20个字符的长度。")]
        public string TravelsTitle { get; set; }//游记标题

        [Required(ErrorMessage = "游记内容不能为空值。")]
        [Display(Name = "游记内容")]
        public string travelsContent { get; set; }//游记内容

    }
}
