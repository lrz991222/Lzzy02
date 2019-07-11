using System;
using System.Collections.Generic;
using System.Text;

namespace ELearning.ViewModels
{
     public  interface IEntityViewModel
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
       
        string OrderNumber { get; set; } // 列表时候需要的序号
        bool IsNew { get; set; }         // 是否是新创建的对象，要特别注意在实际使用时候的赋值

   
    }
}
