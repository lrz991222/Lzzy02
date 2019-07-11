using ELearning.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZebraWeb.Models
{

    public class CityVM
    {
        public Guid Id { get; set; }

        
        public List<City> Cities { get; set; }
        

        public SelectList Genres { get; set; }

        public Theme Theme { get; set; }


           [Display(Name = "城市名称")]
        [StringLength(8, ErrorMessage = "你输入的数据超出限制16个字符的长度。")]
        [Required(ErrorMessage = "城市名称不能为空值。")]
        public string CitCityName { get; set; }


        [Display(Name = "省份名称")]
        [StringLength(8, ErrorMessage = "你输入的数据超出限制16个字符的长度。")]
        [Required(ErrorMessage = "省份名称不能为空值。")]
        public string Province { get; set; }
    }
}

