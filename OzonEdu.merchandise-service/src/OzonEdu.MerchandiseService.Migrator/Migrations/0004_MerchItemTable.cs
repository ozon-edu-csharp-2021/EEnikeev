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
                .WithColumn("item_type_id").AsInt32().NotNullable()
                .WithColumn("clothing_size_id").AsInt32();
        }

        public override void Down()
        {
            Delete.Table("merch_items");
        }
    }
}