namespace Cashflow.Bot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subscriptions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubscriptionEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TopicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TopicEntities", t => t.TopicId, cascadeDelete: true)
                .ForeignKey("dbo.UserEntities", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TopicId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubscriptionEntities", "UserId", "dbo.UserEntities");
            DropForeignKey("dbo.SubscriptionEntities", "TopicId", "dbo.TopicEntities");
            DropIndex("dbo.SubscriptionEntities", new[] { "TopicId" });
            DropIndex("dbo.SubscriptionEntities", new[] { "UserId" });
            DropTable("dbo.SubscriptionEntities");
        }
    }
}
