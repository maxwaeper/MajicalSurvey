namespace MajicalSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewEntitiesConnection2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Answers", "InsertedNumber", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Answers", "InsertedNumber", c => c.Int(nullable: false));
        }
    }
}
