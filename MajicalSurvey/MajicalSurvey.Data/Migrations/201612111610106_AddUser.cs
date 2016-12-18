namespace MajicalSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Answers_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answers", t => t.Answers_Id)
                .Index(t => t.Answers_Id);
            
            DropColumn("dbo.Answers", "Score");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "Score", c => c.Int(nullable: false));
            DropForeignKey("dbo.Users", "Answers_Id", "dbo.Answers");
            DropIndex("dbo.Users", new[] { "Answers_Id" });
            DropTable("dbo.Users");
        }
    }
}
