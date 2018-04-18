namespace BocceeBall_02.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWinnerID : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Games", name: "Team_ID", newName: "WinnerID");
            RenameIndex(table: "dbo.Games", name: "IX_Team_ID", newName: "IX_WinnerID");
            AlterColumn("dbo.Games", "HomeScore", c => c.Int());
            AlterColumn("dbo.Games", "AwayScore", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Games", "AwayScore", c => c.Int(nullable: false));
            AlterColumn("dbo.Games", "HomeScore", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Games", name: "IX_WinnerID", newName: "IX_Team_ID");
            RenameColumn(table: "dbo.Games", name: "WinnerID", newName: "Team_ID");
        }
    }
}
