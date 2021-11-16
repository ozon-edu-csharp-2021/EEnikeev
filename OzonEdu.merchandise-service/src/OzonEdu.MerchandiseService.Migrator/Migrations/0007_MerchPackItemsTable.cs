using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(7)]
    public class MerchPackItemsTable : Migration 
    {
        public override void Up()
        {
            Create.Table("merch_pack_items")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("pack_id").AsInt32()
                .WithColumn("merch_item_id").AsInt64()
                .WithColumn("quantity").AsInt32();
        }

        public override void Down()
        {
            Delete.Table("merch_pack_items");
        }
    }
}