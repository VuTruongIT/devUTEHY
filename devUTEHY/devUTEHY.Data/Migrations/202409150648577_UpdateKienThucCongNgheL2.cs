namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateKienThucCongNgheL2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KienThucCongNghe", "STT", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KienThucCongNghe", "STT");
        }
    }
}
