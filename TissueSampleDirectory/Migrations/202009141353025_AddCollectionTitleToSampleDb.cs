namespace TissueSampleDirectory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCollectionTitleToSampleDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CollectionModels", "Collection_Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CollectionModels", "Collection_Title");
        }
    }
}
