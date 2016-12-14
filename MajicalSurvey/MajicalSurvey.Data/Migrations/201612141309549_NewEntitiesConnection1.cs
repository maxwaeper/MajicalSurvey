namespace MajicalSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewEntitiesConnection1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "RadioButtonName", c => c.String());
            AddColumn("dbo.Answers", "InsertedName", c => c.String());
            AddColumn("dbo.Answers", "InsertedNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Answers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "Name", c => c.String());
            DropColumn("dbo.Answers", "InsertedNumber");
            DropColumn("dbo.Answers", "InsertedName");
            DropColumn("dbo.Answers", "RadioButtonName");
        }
    }
}
