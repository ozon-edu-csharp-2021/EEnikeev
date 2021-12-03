using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(7)]
    public class MerchPackItemsTable : Migration 
    {
        public override void Up()
        {
            Execute.Sql(@"
                        CREATE TABLE merch_pack_items(
                            id SERIAL PRIMARY KEY,
                            pack_id INT NOT NULL,
                            merch_item_id BIGINT NOT NULL,
                            quantity INT NOT NULL
                        )");
            
            // Create.Table("merch_pack_items")
            //     .WithColumn("id").AsInt32().PrimaryKey()
            //     .WithColumn("pack_id").AsInt32().NotNullable()
            //     .WithColumn("merch_item_id").AsInt64().NotNullable()
            //     .WithColumn("quantity").AsInt32().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("merch_pack_items");
        }
    }
}