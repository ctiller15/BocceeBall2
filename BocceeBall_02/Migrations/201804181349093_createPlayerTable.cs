namespace BocceeBall_02.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createPlayerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TeamID = c.Int(),
                        FullName = c.String(),
                        NickName = c.String(),
                        Number = c.Int(nullable: false),
                        ThrowingArm = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teams", t => t.TeamID)
                .Index(t => t.TeamID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "TeamID", "dbo.Teams");
            DropIndex("dbo.Players", new[] { "TeamID" });
            DropTable("dbo.Players");
        }
    }
}
