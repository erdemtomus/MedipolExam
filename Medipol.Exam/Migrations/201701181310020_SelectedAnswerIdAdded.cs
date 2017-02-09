namespace Medipol.Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SelectedAnswerIdAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "SelectedAnswerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "SelectedAnswerId");
        }
    }
}
