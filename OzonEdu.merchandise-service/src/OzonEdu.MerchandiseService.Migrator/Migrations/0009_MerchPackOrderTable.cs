using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(9)]
    public class MerchPackOrderTable : Migration
    {
        public override void Up()
        {
            Create.Table("merch_pack_orders")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("employee_id").AsInt64().NotNullable()
                .WithColumn("merch_pack_id").AsInt32()
                .WithColumn("is_given").AsBoolean().NotNullable()
                .WithColumn("giving_date").AsString();
        }

        public override void Down()
        {
            Delete.Table("merch_pack_orders");
        }
    }
}