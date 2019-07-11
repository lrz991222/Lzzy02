using ELearning.Entities;
using ELearning.ORM.SqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZebraWeb.Models;

namespace ZebraWeb
{
    public class ModelList<T> : List<CityVM>
    {
      
        
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public ModelList(List<CityVM> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }


        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static async Task<ModelList<CityVM>> CitiesAsync(CityVM cityVM, int pageIndex, int pageSize, SqlServerDbContext _context)
        {
            
            var source = from m in _context.Citys select m;
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            List<CityVM> cityVMs = new List<CityVM>();

         
            foreach (var i in items)
            {
                foreach (var l in cityVMs)
                {
                    l.CitCityName = i.CityName;
                    l.Id = i.Id;
                    l.Province = i.Province;
                    l.Theme = i.Theme;
                }
               
            }
         
            return new ModelList<CityVM>(cityVMs, count, pageIndex, pageSize);
        }
    }
}
