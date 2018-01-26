namespace Portal.CMS.Entities.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RemovePagePartialEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PageAssociations", "PagePartialId", "dbo.PagePartials");
            DropIndex("dbo.PageAssociations", new[] { "PagePartialId" });
            DropColumn("dbo.PageAssociations", "PagePartialId");
            DropTable("dbo.PagePartials");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.PagePartials",
                c => new
                {
                    PagePartialId = c.Int(nullable: false, identity: true),
                    RouteArea = c.String(),
                    RouteController = c.String(nullable: false),
                    RouteAction = c.String(nullable: false),
                })
                .PrimaryKey(t => t.PagePartialId);

            AddColumn("dbo.PageAssociations", "PagePartialId", c => c.Int());
            CreateIndex("dbo.PageAssociations", "PagePartialId");
            AddForeignKey("dbo.PageAssociations", "PagePartialId", "dbo.PagePartials", "PagePartialId");
        }
    }
}