namespace TissueSampleDirectory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTitleToSampleDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SampleModels", "Collection_Title", c => c.String());
            DropColumn("dbo.CollectionModels", "Collection_Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CollectionModels", "Collection_Title", c => c.String());
            DropColumn("dbo.SampleModels", "Collection_Title");
        }
    }
}
