namespace BocceeBall_02.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixWinner : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Games", "WinnerID", "dbo.Teams", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "WinnerID", "dbo.Teams");
        }
    }
}
