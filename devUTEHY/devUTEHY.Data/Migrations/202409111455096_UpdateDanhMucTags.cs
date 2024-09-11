namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDanhMucTags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DanhMucTags",
                c => new
                    {
                        DanhMucID = c.Int(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.DanhMucID, t.TagID })
                .ForeignKey("dbo.DanhMuc", t => t.DanhMucID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.DanhMucID)
                .Index(t => t.TagID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DanhMucTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.DanhMucTags", "DanhMucID", "dbo.DanhMuc");
            DropIndex("dbo.DanhMucTags", new[] { "TagID" });
            DropIndex("dbo.DanhMucTags", new[] { "DanhMucID" });
            DropTable("dbo.DanhMucTags");
        }
    }
}
