using ELearning.UserAndRole;
using System;
using System.ComponentModel.DataAnnotations;

namespace ELearning.Entities
{
    //结伴
    public class GoWith: IEntityBase
    {
        [Key]

        public Guid Id{ get; set; }

        public string GowithTitle { get; set; }//结伴标题

        public string GowithContent { get; set; }//结伴内容

        public string GowithSynopsis { get; set; }//结伴简介
        public DateTime DepartureDate { get; set; }//发布时间

        public DateTime EndDate { get; set; }//结束时间

        public virtual ApplicationUser Person { get; set; }//   发起人

        public string Tel { get; set; }//联系电话
        public string Image { get; set; }//图片

        public City City { get; set; }//目的地

        public int Num { get; set; }//人数

        public GoWith ()
        {
            Id= new Guid();
            DepartureDate = DateTime.Now;
        }


    }
}
