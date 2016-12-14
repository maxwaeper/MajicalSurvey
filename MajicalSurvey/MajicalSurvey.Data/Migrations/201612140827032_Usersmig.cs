namespace MajicalSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Usersmig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "Users_Id", "dbo.Users");
            DropIndex("dbo.Answers", new[] { "Users_Id" });
            AddColumn("dbo.Users", "Answer_Id", c => c.Int());
            CreateIndex("dbo.Users", "Answer_Id");
            AddForeignKey("dbo.Users", "Answer_Id", "dbo.Answers", "Id");
            DropColumn("dbo.Answers", "Users_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "Users_Id", c => c.Int());
            DropForeignKey("dbo.Users", "Answer_Id", "dbo.Answers");
            DropIndex("dbo.Users", new[] { "Answer_Id" });
            DropColumn("dbo.Users", "Answer_Id");
            CreateIndex("dbo.Answers", "Users_Id");
            AddForeignKey("dbo.Answers", "Users_Id", "dbo.Users", "Id");
        }
    }
}
