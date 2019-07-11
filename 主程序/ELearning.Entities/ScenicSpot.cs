using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELearning.Entities
{
   public class ScenicSpot : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }

        //等级
        public string Grade { get; set; }

        //东经
        public double Lng { get; set; }

        //北纬
        public double Lat { get; set;}

        //景区名称
        public string Name { get; set; }

        //地址
        public string Addr { get; set; }

        //景区类型
        public string Type { get; set; }

        //开发时间
        public string Opentime { get; set; }

        //电话
        public int Tel { get; set; }

        //图片地址 
        public string Url { get; set; }

        //绑定的主题
        public Theme Theme { get; set; }


        //绑定的标签
        public Label Label { get; set; }

        //描述
        public string Describe { get; set; }


        public ScenicSpot()
        {
            Id = new Guid();
        }
    }
}
