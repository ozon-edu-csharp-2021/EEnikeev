using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(4)]
    public class MerchItemsTable : Migration 
    {
        public override void Up()
        {
            Execute.Sql(@"
                        CREATE TABLE merch_items(
                            id BIGSERIAL PRIMARY KEY,
                            sku_id INT NOT NULL,
                            item_type_id INT NOT NULL                            
                        );");
            
            // Create
            //     .Table("merch_items")
            //     .WithColumn("id").AsInt64().Identity().PrimaryKey()
            //     .WithColumn("sku_id").AsInt64().NotNullable()
            //     .WithColumn("item_type_id").AsInt32().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("merch_items");
        }
    }
}