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
            (pack_id, merch_item_id, quantity)
            VALUES
            (10, 3, 1),
            (10, 5, 1)
            ON CONFLICT DO NOTHING");
            
            // conference listener pack
            Execute.Sql(@"
            INSERT INTO merch_pack_items
            (pack_id, merch_item_id, quantity)
            VALUES
            (20, 1, 1),
            (20, 3, 1),
            (20, 5, 2)
            ON CONFLICT DO NOTHING");
            
            // conference speaker pack
            Execute.Sql(@"
            INSERT INTO merch_pack_items
            (pack_id, merch_item_id, quantity)
            VALUES
            (30, 1, 1),
            (30, 2, 1),
            (30, 3, 1),
            (30, 5, 2),
            (30, 6, 1)
            ON CONFLICT DO NOTHING");
            
            // probation period ending pack
            Execute.Sql(@"
            INSERT INTO merch_pack_items
            (pack_id, merch_item_id, quantity)
            VALUES
            (40, 1, 1),
            (40, 3, 2),
            (40, 5, 2)
            ON CONFLICT DO NOTHING");


            // veteran pack
            Execute.Sql(@"
            INSERT INTO merch_pack_items
            (pack_id, merch_item_id, quantity)
            VALUES
            (50, 1, 2),
            (50, 2, 1),
            (50, 3, 3),
            (50, 5, 3),
            (50, 4, 1),
            (50, 6, 2)
            ON CONFLICT DO NOTHING");

        }
    }
}