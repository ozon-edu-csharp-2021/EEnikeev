using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(7)]
    public class MerchPackItemsTable : Migration 
    {
        public override void Up()
        {
            Create.Table("merch_pack_items")
                .WithColumn("id").AsInt32().PrimaryKey()
                .WithColumn("pack_id").AsInt32().NotNullable()
                .WithColumn("merch_item_id").AsInt64().NotNullable()
                .WithColumn("quantity").AsInt32().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("merch_pack_items");
        }
    }
}