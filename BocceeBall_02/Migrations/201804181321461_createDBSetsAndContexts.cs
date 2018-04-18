namespace BocceeBall_02.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDBSetsAndContexts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HomeTeamID = c.Int(),
                        AwayTeamID = c.Int(),
                        HomeScore = c.Int(nullable: false),
                        AwayScore = c.Int(nullable: false),
                        DateHappened = c.DateTime(nullable: false),
                        Notes = c.String(),
                        Team_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teams", t => t.Team_ID)
                .ForeignKey("dbo.Teams", t => t.AwayTeamID)
                .ForeignKey("dbo.Teams", t => t.HomeTeamID)
                .Index(t => t.HomeTeamID)
                .Index(t => t.AwayTeamID)
                .Index(t => t.Team_ID);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Mascot = c.String(),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "HomeTeamID", "dbo.Teams");
            DropForeignKey("dbo.Games", "AwayTeamID", "dbo.Teams");
            DropForeignKey("dbo.Games", "Team_ID", "dbo.Teams");
            DropIndex("dbo.Games", new[] { "Team_ID" });
            DropIndex("dbo.Games", new[] { "AwayTeamID" });
            DropIndex("dbo.Games", new[] { "HomeTeamID" });
            DropTable("dbo.Teams");
            DropTable("dbo.Games");
        }
    }
}
