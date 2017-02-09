namespace Medipol.Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SelectedQAnswerId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "SelectedQAnswerId", c => c.Int());
            DropColumn("dbo.Questions", "SelectedAnswerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "SelectedAnswerId", c => c.Int(nullable: false));
            DropColumn("dbo.Questions", "SelectedQAnswerId");
        }
    }
}
