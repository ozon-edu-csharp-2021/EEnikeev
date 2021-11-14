using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(4)]
    public class MerchItemTable : Migration 
    {
        public override void Up()
        {
            Create
                .Table("merch_items")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("sku_id").AsInt64().NotNullable()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("clothing_size").AsInt64().NotNullable()
                .WithColumn("quantity").AsInt32().NotNullable()
                .WithColumn("tags").AsString();
        }

        public override void Down()
        {
            Delete.Table("merch_items");
        }
    }
}