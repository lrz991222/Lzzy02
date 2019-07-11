using ELearning.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZebraWeb.Models
{
    public class ScenicSpotVM
    {
 
        public Guid Id { get; set; }

        [Display(Name = "等级")]
        [StringLength(8, ErrorMessage = "你输入的数据超出限制16个字符的长度。")]
        [Required(ErrorMessage = "等级不能为空值。")]
        public string Grade { get; set; }

    

        [Display(Name = "东经")]
        [StringLength(8, ErrorMessage = "你输入的数据超出限制16个字符的长度。")]
        [Required(ErrorMessage = "东经不能为空值。")]
        public double Lng { get; set; }

        [Display(Name = "北纬")]
        [StringLength(8, ErrorMessage = "你输入的数据超出限制16个字符的长度。")]
        [Required(ErrorMessage = "北纬不能为空值。")]
        public double Lat { get; set; }

      
        [Display(Name = "景区名称")]
        [StringLength(15, ErrorMessage = "你输入的数据超出限制30个字符的长度。")]
        [Required(ErrorMessage = "景区名称不能为空值。")]
        public string Name { get; set; }

        [Display(Name = "地址")]
        [StringLength(100, ErrorMessage = "你输入的数据超出限制200个字符的长度。")]
        [Required(ErrorMessage = "地址不能为空值。")]
        public string Addr { get; set; }

        [Display(Name = "景区类型")]
        [StringLength(8, ErrorMessage = "你输入的数据超出限制16个字符的长度。")]
        [Required(ErrorMessage = "景区类型不能为空值。")]
        public string Type { get; set; }

        [Display(Name = "开发时间")]
        [StringLength(18, ErrorMessage = "你输入的数据超出限制36个字符的长度。")]
        [Required(ErrorMessage = "开发时间不能为空值。")]
        public string Opentime { get; set; }

        //电话
        [Display(Name = "固定电话")]
        [StringLength(18, ErrorMessage = "你输入的数据超出限制36个字符的长度。")]
        [Required(ErrorMessage = "电话不能为空值。")]
        public int Tel { get; set; }

        //景区网址
        public string Url { get; set; }

        public string Describe { get; set; }

        public List<Theme> Theme { get; set; }

        //绑定的主题
        public Theme Themes { get; set; }


        //绑定的标签
        public Label Labels { get; set; }
        //绑定的标签
        public List<Label> Label { get; set; }


      
        public List<ScenicSpot> ScenicSpots { get; set; }
    }
}
