using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(1)]
    public class SkuTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE skus(
                    id BIGSERIAL PRIMARY KEY);"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists skus;");
        }
    }
}