using ELearning.Entities;
using ELearning.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZebraWeb.Models
{
    public class TraveslVM
    {


        public Guid TravelsID { get; set; }//游记ID

        public string TravelsTitle { get; set; }//游记标题
        
        public List< TravelNotes >TravelNotes{ get; set; }//游记内容

        public DateTime TravelsTime { get; set; }//游记发布时间

        public virtual ApplicationUser User { get; set; }//发表人

        public int Like { get; set; } = 0;//赞，喜欢

        public int Collection { get; set; } = 0;//收藏

        public int Share { get; set; } = 0;//分享


    }
}
