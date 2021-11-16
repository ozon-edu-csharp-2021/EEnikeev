using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(9)]
    public class MerchPackOrderTable : Migration
    {
        public override void Up()
        {
            Create.Table("merch_pack_order")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("employee_id").AsInt64().NotNullable()
                .WithColumn("merch_pack_id").AsInt32().NotNullable()
                .WithColumn("is_given").AsBoolean().NotNullable()
                .WithColumn("giving_date").AsDateTime();
        }

        public override void Down()
        {
            Delete.Table("merch_pack_order");
        }
    }
}