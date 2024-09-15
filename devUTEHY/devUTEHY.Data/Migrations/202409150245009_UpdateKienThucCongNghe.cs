namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateKienThucCongNghe : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.KienThucCongNghe", "STT");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KienThucCongNghe", "STT", c => c.Int());
        }
    }
}
