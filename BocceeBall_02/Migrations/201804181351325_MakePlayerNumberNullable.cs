namespace BocceeBall_02.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakePlayerNumberNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "Number", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "Number", c => c.Int(nullable: false));
        }
    }
}
