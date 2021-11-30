using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(5)]
    public class TagsTable : Migration 
    {
        public override void Up()
        {
            Execute.Sql(@"
                        CREATE TABLE tags(
                            id BIGSERIAL PRIMARY KEY,
                            merch_item_id BIGINT NOT NULL,
                            tag VARCHAR NULL
                        );");
            
            // Create.Table("tags")
            //     .WithColumn("id").AsInt64().Identity().PrimaryKey()
            //     .WithColumn("merch_item_id").AsInt64().NotNullable()
            //     .WithColumn("tag").AsString().Nullable();
        }

        public override void Down()
        {
            Delete.Table("tags");
        }
    }
}