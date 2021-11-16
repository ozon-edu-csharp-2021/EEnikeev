using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(6)]
    public class MerchPackTable : Migration
    {
        public override void Up()
        {
            /*Execute.Sql(@"
                        CREATE TABLE if not exists merch_packs(
                            id BIGSERIAL PRIMARY KEY,
                            name TEXT NOT NULL);");*/

            Create.Table("merch_packs")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable();
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists merch_packs;");
        }
    }
}