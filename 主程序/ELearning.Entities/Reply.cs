using ELearning.UserAndRole;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELearning.Entities
{
    //评论
    public class Reply : IEntityBase
    {
        [Key]

        public Guid Id { get; set; }

        public string Content { get; set; }//评论内容

        public virtual ApplicationUser Person { get; set; }//所属用户

        public virtual Travels Travels { get; set; }//所属游记

        public DateTime ReplyTime { get; set; }//评论时间

        public virtual Reply ParentReply { get; set; }   //上级回复

        public DateTime CreateDateTime { get; set; }  //回复时间

        public int Like { get; set; } = 0;//赞，喜欢

        public Reply()
        {
            Id = Guid.NewGuid();
            ReplyTime = DateTime.Now;
            CreateDateTime = DateTime.Now;
        }
    }
}
