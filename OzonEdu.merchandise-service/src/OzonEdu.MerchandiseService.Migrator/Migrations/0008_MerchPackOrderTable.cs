using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(8)]
    public class MerchPackOrderTable : Migration
    {
        public override void Up()
        {
            Create.Table("merch_pack_order")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("employee_id").AsInt64()
                .WithColumn("merch_pack_id").AsInt64()
                .WithColumn("is_given").AsBoolean()
                .WithColumn("giving_date").AsDateTime();
        }

        public override void Down()
        {
            Delete.Table("merch_pack_order");
        }
    }
}