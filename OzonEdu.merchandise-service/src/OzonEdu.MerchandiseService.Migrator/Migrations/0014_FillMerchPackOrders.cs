using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(14)]
    public class FillMerchPackOrders : ForwardOnlyMigration 
    {
        public override void Up()
        {
            //(1, 3, NULL,  false,  NULL),
            Execute.Sql(@"
            INSERT INTO merch_pack_orders
            (employee_id, clothing_size_id, merch_pack_id, is_given, giving_date)
            VALUES            
            (2, 3, 10,    false,  NULL ),
            (3, 3, 20,    true,   '2020-12-17'),
            (4, 3, 10,    true ,  '2018-12-17'),
            (5, 3, 10,    true,   '2019-12-17')
            ON CONFLICT DO NOTHING            
            ");
        }
    }
}