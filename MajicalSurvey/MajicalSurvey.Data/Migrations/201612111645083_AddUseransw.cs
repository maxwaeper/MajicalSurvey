namespace MajicalSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUseransw : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Answers_Id", "dbo.Answers");
            DropIndex("dbo.Users", new[] { "Answers_Id" });
            AddColumn("dbo.Answers", "Users_Id", c => c.Int());
            CreateIndex("dbo.Answers", "Users_Id");
            AddForeignKey("dbo.Answers", "Users_Id", "dbo.Users", "Id");
            DropColumn("dbo.Users", "Answers_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Answers_Id", c => c.Int());
            DropForeignKey("dbo.Answers", "Users_Id", "dbo.Users");
            DropIndex("dbo.Answers", new[] { "Users_Id" });
            DropColumn("dbo.Answers", "Users_Id");
            CreateIndex("dbo.Users", "Answers_Id");
            AddForeignKey("dbo.Users", "Answers_Id", "dbo.Answers", "Id");
        }
    }
}
