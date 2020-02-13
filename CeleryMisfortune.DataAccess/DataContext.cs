using CeleryMisfortune.Model.Base;
using KnifeZ.CelestialMisfortune.Player;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using WalkingTec.Mvvm.Core;

namespace CeleryMisfortune.DataAccess
{
    public class DataContext : FrameworkContext
    {
        public DbSet<BaseOption> BaseOptions { get; set; }
        public DbSet<PlayerInfo> PlayerInfos { get; set; }
        public DbSet<PlayerProperty> PlayerProperties { get; set; }
        public DbSet<PlayerSpecial> PlayerSpecials { get; set; }
        public DbSet<PlayerState> PlayerStates { get; set; }
        public DbSet<PlayerAttribute> PlayerAttributes { get; set; }
        public DataContext(string cs, DBTypeEnum dbtype)
             : base(cs, dbtype)
        {
        }

    }

    /// <summary>
    /// 为EF的Migration准备的辅助类，填写完整连接字符串和数据库类型
    /// 就可以使用Add-Migration和Update-Database了
    /// </summary>
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            return new DataContext("Server=122.51.169.162;Database=CeleryMisfortune_db; User ID=sa;Password=sacer1103.;", DBTypeEnum.SqlServer);
        }
    }

}
