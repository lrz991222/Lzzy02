using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ELearning.Entities
{
    //城市
    public class City : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string CityName { get; set; }
        //省份
        public string Province { get; set; }

        public virtual Theme Theme { get;set;}
     


        public City()
        {
            Id = new Guid();  
        }
    }

}
