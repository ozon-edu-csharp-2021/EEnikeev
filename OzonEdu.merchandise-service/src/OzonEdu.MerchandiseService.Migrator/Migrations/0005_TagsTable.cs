using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(5)]
    public class TagsTable : Migration 
    {
        public override void Up()
        {
            Create.Table("tags")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("merch_item_id").AsInt64().NotNullable()
                .WithColumn("tag").AsString();
        }

        public override void Down()
        {
            Delete.Table("tags");
        }
    }
}