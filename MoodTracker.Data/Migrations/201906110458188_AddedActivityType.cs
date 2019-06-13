namespace MoodTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedActivityType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActivityType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        CreationStamp = c.DateTime(nullable: false),
                        ModificationStamp = c.DateTime(),
                        Addedby = c.String(),
                        ModifiedBy = c.String(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        IsArchived = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ActivityType");
        }
    }
}
