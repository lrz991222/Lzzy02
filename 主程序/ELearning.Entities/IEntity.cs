using System;
using System.Collections.Generic;
using System.Text;

namespace ELearning.Entities
{
    public interface IEntity : IEntityBase
    {
        string Name { get; set; }
        string Synopsis { get; set; }
        string SortCode { get; set; }
    }
}
