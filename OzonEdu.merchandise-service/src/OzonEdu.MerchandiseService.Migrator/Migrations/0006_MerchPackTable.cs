using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(6)]
    public class MerchPackTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                        CREATE TABLE  merch_packs(
                            id SERIAL PRIMARY KEY,
                            name VARCHAR(30) NOT NULL
                        );");

            // Create.Table("merch_packs")
            //     .WithColumn("id").AsInt32().Identity().PrimaryKey()
            //     .WithColumn("name").AsString().NotNullable();
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists merch_packs;");
        }
    }
}