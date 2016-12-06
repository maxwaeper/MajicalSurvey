namespace MajicalSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Score = c.Int(nullable: false),
                        Questions_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.Questions_Id)
                .Index(t => t.Questions_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surveys_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Surveys", t => t.Surveys_Id)
                .Index(t => t.Surveys_Id);
            
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Surveys_Id", "dbo.Surveys");
            DropForeignKey("dbo.Answers", "Questions_Id", "dbo.Questions");
            DropIndex("dbo.Questions", new[] { "Surveys_Id" });
            DropIndex("dbo.Answers", new[] { "Questions_Id" });
            DropTable("dbo.Surveys");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
