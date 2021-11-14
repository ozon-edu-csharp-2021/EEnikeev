using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(6)]
    public class EmployeeTable : Migration 
    {
        public override void Up()
        {
            Create.Table("employee")
                .WithColumn("firstname").AsString().NotNullable()
                .WithColumn("lastname").AsString().NotNullable()
                .WithColumn("hiring_date").AsDateTime().NotNullable()
                .WithColumn("email").AsString().NotNullable()
                .WithColumn("merch_pack_id").AsInt64()
                .WithColumn("merch_is_given").AsBoolean()
                .WithColumn("merch_given_date").AsDateTime();
        }

        public override void Down()
        {
            Delete.Table("employee");
        }
    }
}