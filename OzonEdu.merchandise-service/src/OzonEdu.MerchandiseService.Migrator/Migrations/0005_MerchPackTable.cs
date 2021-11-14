using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(5)]
    public class MerchPackTable:Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                        CREATE TABLE if not exists merch_packs(
                            id BIGSERIAL PRIMARY KEY,
                            name TEXT NOT NULL,
                            merch_items INT[]                            
                        )");
            
            /*Create.Table("merch_packs")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("merch_items").as*/
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists merch_packs;");
        }
    }
}