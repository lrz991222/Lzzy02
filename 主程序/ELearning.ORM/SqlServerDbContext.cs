
using ELearning.Entities;
using ELearning.UserAndRole;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELearning.ORM.SqlServer
{
    public class SqlServerDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options) { }



        #region 用户与角色相关
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

     
        #endregion

        #region 景区相关
        public DbSet<Theme> Themes { get; set; }
        public DbSet<City> Citys { get; set; }

        public DbSet<Label> Label { get; set; }

        public DbSet<ScenicSpot> ScenicSpot { get; set; }
        #endregion

        #region 游记相关
        public DbSet<Follow> Follow { get; set; }

        public DbSet<Reply> Reply { get; set; }

        public DbSet<Travels> Travels { get; set; }

        public DbSet<TravelNotes> TravelNotes { get; set; }

        #endregion

        #region 结伴相关
        public DbSet<GoWith> GoWith { get; set; }

        public DbSet<GoWithMenber> GoWithMenber { get; set; }
        #endregion

        /// <summary>
        /// 如果不需要 DbSet<T> 所定义的属性名称作为数据库表的名称，可以在下面的位置自己重新定义
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
