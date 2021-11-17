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
            (id, employee_id, clothing_size_id, merch_pack_id, is_given, giving_date)
            VALUES
            (1, 1, 3, NULL,  false,  NULL),
            (2, 2, 3, 10,    false,  NULL ),
            (3, 3, 3, 20,    true,   '2020-12-17 01:10:54.000000'),
            (4, 4, 3, 10,    true ,  '2018-12-17 01:10:54.000000'),
            (5, 5, 3, 10,    true,   '2019-12-17 01:10:54.000000')
            ON CONFLICT DO NOTHING            
            ");
        }
    }
}