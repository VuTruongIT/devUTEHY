using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using devUTEHY.Model.Models;

namespace devUTEHY.Data
{
    public class devUTEHYDbContext : DbContext
    {
        public devUTEHYDbContext() : base("DevUTEHYConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<KhoaHoc> KhoaHocs { set; get; }
        public DbSet<KhoaHocTags> KhoaHocTags { set; get; }
        public DbSet<KienThucCongNghe> KienThucCongNghes { set; get; }
        public DbSet<KienThucCongNgheTags> KienThucCongNgheTags { set; get; }
        public DbSet<LoaiCongNghe> LoaiCongNghes { set; get; }
        public DbSet<Tag> Tags { set; get; }


        public DbSet<Error> Errors { set; get; }
        public DbSet<Slide> Slides { set; get; }
        public DbSet<SupportOnline> SupportOnlines { set; get; }
        public DbSet<SystemConfig> SystemConfigs { set; get; }
        public DbSet<VisitorStatistic> VisitorStatistics { set; get; }


        public static devUTEHYDbContext Create()
        {
            return new devUTEHYDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
        }
    }
}
