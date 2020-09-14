namespace TissueSampleDirectory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCollectionId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CollectionModels", "Collection_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CollectionModels", "Collection_Id");
        }
    }
}
