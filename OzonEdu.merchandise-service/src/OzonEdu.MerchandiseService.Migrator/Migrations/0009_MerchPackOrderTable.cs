using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(9)]
    public class MerchPackOrderTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                        CREATE TABLE merch_pack_orders(
                            id BIGSERIAL PRIMARY KEY,
                            employee_id BIGINT NOT NULL,
                            clothing_size_id INT NULL,
                            merch_pack_id INT NOT NULL,
                            is_given BOOLEAN DEFAULT false NOT NULL,
                            giving_date DATE NULL 
                        );
                        ");
            
            // Create.Table("merch_pack_orders")
            //     //.WithColumn("id").AsInt64().Identity().PrimaryKey()
            //     .WithColumn("employee_id").AsInt64().NotNullable()
            //     .WithColumn("clothing_size_id").AsInt32().Nullable()
            //     .WithColumn("merch_pack_id").AsInt32().Nullable()
            //     .WithColumn("is_given").AsBoolean().NotNullable()
            //     .WithColumn("giving_date").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("merch_pack_orders");
        }
    }
}