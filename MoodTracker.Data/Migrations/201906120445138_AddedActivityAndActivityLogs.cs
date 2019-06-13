namespace MoodTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedActivityAndActivityLogs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityTypeId = c.Int(nullable: false),
                        Title = c.String(),
                        CourseInfo = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        GradeWorth = c.String(),
                        InitialMood = c.Int(nullable: false),
                        CreationStamp = c.DateTime(nullable: false),
                        ModificationStamp = c.DateTime(),
                        Addedby = c.String(),
                        ModifiedBy = c.String(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        IsArchived = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActivityType", t => t.ActivityTypeId, cascadeDelete: true)
                .Index(t => t.ActivityTypeId);
            
            CreateTable(
                "dbo.ActivityLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityId = c.Int(nullable: false),
                        Mood = c.Int(nullable: false),
                        Note = c.String(),
                        CreationStamp = c.DateTime(nullable: false),
                        ModificationStamp = c.DateTime(),
                        Addedby = c.String(),
                        ModifiedBy = c.String(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        IsArchived = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activity", t => t.ActivityId, cascadeDelete: true)
                .Index(t => t.ActivityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activity", "ActivityTypeId", "dbo.ActivityType");
            DropForeignKey("dbo.ActivityLog", "ActivityId", "dbo.Activity");
            DropIndex("dbo.ActivityLog", new[] { "ActivityId" });
            DropIndex("dbo.Activity", new[] { "ActivityTypeId" });
            DropTable("dbo.ActivityLog");
            DropTable("dbo.Activity");
        }
    }
}
