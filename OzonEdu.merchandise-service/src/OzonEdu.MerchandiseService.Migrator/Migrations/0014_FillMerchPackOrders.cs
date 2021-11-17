using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(14)]
    public class FillMerchPackOrders : ForwardOnlyMigration 
    {
        public override void Up()
        {
            Execute.Sql(@"
            INSERT INTO merch_pack_orders
            (id, employee_id, merch_pack_id, is_given, giving_date)
            VALUES
            (1, 1, NULL,  false,  NULL),
            (2, 2, 1,     false,  NULL ),
            (3, 3, 2,     true,   '2020-12-17 01:10:54.000000')
            ON CONFLICT DO NOTHING            
            ");
        }
    }
}