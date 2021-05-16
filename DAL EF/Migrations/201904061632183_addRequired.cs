namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Answers", "AnswerText", c => c.String(nullable: false, maxLength: 90));
            AlterColumn("dbo.Questions", "QuestionText", c => c.String(nullable: false, maxLength: 90));
            AlterColumn("dbo.Tests", "Name", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tests", "Name", c => c.String(maxLength: 40));
            AlterColumn("dbo.Questions", "QuestionText", c => c.String(maxLength: 90));
            AlterColumn("dbo.Answers", "AnswerText", c => c.String(maxLength: 90));
        }
    }
}
