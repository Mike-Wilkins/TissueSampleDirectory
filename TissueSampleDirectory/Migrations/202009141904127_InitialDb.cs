namespace TissueSampleDirectory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SampleModels", "Last_Updated", c => c.String());
            DropColumn("dbo.SampleModels", "Collection_Id");
            DropColumn("dbo.SampleModels", "Collection_Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SampleModels", "Collection_Title", c => c.String());
            AddColumn("dbo.SampleModels", "Collection_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.SampleModels", "Last_Updated", c => c.String(nullable: false));
        }
    }
}
