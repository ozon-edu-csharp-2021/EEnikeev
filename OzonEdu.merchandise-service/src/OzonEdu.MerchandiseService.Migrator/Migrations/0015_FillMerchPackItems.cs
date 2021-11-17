using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(15)]
    public class FillMerchPackItems : ForwardOnlyMigration 
    {
        public override void Up()
        {
            // welcome pack
            Execute.Sql(@"
            INSERT INTO merch_pack_items
            (id, pack_id, merch_item_id, quantity)
            VALUES
            (1, 10, 3, 1),
            (2, 10, 5, 1)
            ON CONFLICT DO NOTHING");
            
            // conference listener pack
            Execute.Sql(@"
            INSERT INTO merch_pack_items
            (id, pack_id, merch_item_id, quantity)
            VALUES
            (3, 20, 1, 1),
            (4, 20, 3, 1),
            (5, 20, 5, 2)
            ON CONFLICT DO NOTHING");
            
            // conference speaker pack
            Execute.Sql(@"
            INSERT INTO merch_pack_items
            (id, pack_id, merch_item_id, quantity)
            VALUES
            ( 6, 30, 1, 1),
            ( 7, 30, 2, 1),
            ( 8, 30, 3, 1),
            ( 9, 30, 5, 2),
            (10, 30, 6, 1)
            ON CONFLICT DO NOTHING");
            
            // probation period ending pack
            Execute.Sql(@"
            INSERT INTO merch_pack_items
            (id, pack_id, merch_item_id, quantity)
            VALUES
            (11, 40, 1, 1),
            (12, 40, 3, 2),
            (13, 40, 5, 2)
            ON CONFLICT DO NOTHING");


            // veteran pack
            Execute.Sql(@"
            INSERT INTO merch_pack_items
            (id, pack_id, merch_item_id, quantity)
            VALUES
            (14, 50, 1, 2),
            (15, 50, 2, 1),
            (16, 50, 3, 3),
            (17, 50, 5, 3),
            (18, 50, 4, 1),
            (19, 50, 6, 2)
            ON CONFLICT DO NOTHING");

        }
    }
}