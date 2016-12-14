namespace MajicalSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewEntitiesConnection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Answer_Id", "dbo.Answers");
            DropIndex("dbo.Users", new[] { "Answer_Id" });
            CreateTable(
                "dbo.UsersAnswers",
                c => new
                    {
                        Users_Id = c.Int(nullable: false),
                        Answers_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Users_Id, t.Answers_Id })
                .ForeignKey("dbo.Users", t => t.Users_Id, cascadeDelete: true)
                .ForeignKey("dbo.Answers", t => t.Answers_Id, cascadeDelete: true)
                .Index(t => t.Users_Id)
                .Index(t => t.Answers_Id);
            
            DropColumn("dbo.Users", "Answer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Answer_Id", c => c.Int());
            DropForeignKey("dbo.UsersAnswers", "Answers_Id", "dbo.Answers");
            DropForeignKey("dbo.UsersAnswers", "Users_Id", "dbo.Users");
            DropIndex("dbo.UsersAnswers", new[] { "Answers_Id" });
            DropIndex("dbo.UsersAnswers", new[] { "Users_Id" });
            DropTable("dbo.UsersAnswers");
            CreateIndex("dbo.Users", "Answer_Id");
            AddForeignKey("dbo.Users", "Answer_Id", "dbo.Answers", "Id");
        }
    }
}
