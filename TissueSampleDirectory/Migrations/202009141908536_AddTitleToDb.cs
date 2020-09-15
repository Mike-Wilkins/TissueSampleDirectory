namespace TissueSampleDirectory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTitleToDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SampleModels", "Collection_Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SampleModels", "Collection_Title");
        }
    }
}
