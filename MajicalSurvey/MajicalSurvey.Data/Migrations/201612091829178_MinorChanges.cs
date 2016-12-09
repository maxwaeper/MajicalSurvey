namespace MajicalSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinorChanges : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Answers", name: "Questions_Id", newName: "Question_Id");
            RenameColumn(table: "dbo.Questions", name: "Surveys_Id", newName: "Survey_Id");
            RenameIndex(table: "dbo.Answers", name: "IX_Questions_Id", newName: "IX_Question_Id");
            RenameIndex(table: "dbo.Questions", name: "IX_Surveys_Id", newName: "IX_Survey_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Questions", name: "IX_Survey_Id", newName: "IX_Surveys_Id");
            RenameIndex(table: "dbo.Answers", name: "IX_Question_Id", newName: "IX_Questions_Id");
            RenameColumn(table: "dbo.Questions", name: "Survey_Id", newName: "Surveys_Id");
            RenameColumn(table: "dbo.Answers", name: "Question_Id", newName: "Questions_Id");
        }
    }
}
