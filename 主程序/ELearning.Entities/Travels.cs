using ELearning.UserAndRole;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace ELearning.Entities
{
    //游记
    public  class Travels
    {
        [Key]
        public Guid TravelsID { get; set; }//游记ID
       
        public string TravelsTitle { get; set; }//游记标题

        //包含
        public virtual ICollection <TravelNotes> TravelNotes { get; set; }//游记内容
    
        public DateTime TravelsTime { get; set; }//游记发布时间

        public virtual ApplicationUser User { get; set; }//发表人

        public int Like { get; set; } = 0;//赞，喜欢

        public int Collection { get; set; } = 0;//收藏

        public int Share { get; set; } = 0;//分享

        //ScenicID绑定的景区

        public Travels()
        {
            TravelsID = new Guid();
            TravelsTime = DateTime.Now;
        }
    }
}
