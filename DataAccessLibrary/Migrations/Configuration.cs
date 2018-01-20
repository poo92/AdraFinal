namespace DataAccessLibrary.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLibrary.AdraFullTestFinalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccessLibrary.AdraFullTestFinalContext context)
        {
            //  This method will be called after migrating to the latest version.
            var accountbalances = new List<AccountBalance>
            {
                new AccountBalance{year=2017, month=1, rnd=5602.02, canteen=639.25, ceocar=-6500.00, marketing=4500.00, parking=5600.25, uid=1},
                new AccountBalance{year=2017, month=2, rnd=10245.00, canteen=4523.02, ceocar=-789.025, marketing=63.02, parking=789.02, uid=1},
                new AccountBalance{year=2017, month=3, rnd=562.02, canteen=6394.25, ceocar=-6540.00, marketing=4500.00, parking=600.25, uid=1},
                new AccountBalance{year=2017, month=4, rnd=560.02, canteen=6394.25, ceocar=-600.00, marketing=450.00, parking=500.25, uid=1},
                new AccountBalance{year=2017, month=5, rnd=602.02, canteen=6539.25, ceocar=-6700.00, marketing=4200.00, parking=5606.25, uid=1},

            };
            accountbalances.ForEach(s => context.AccountBalances.AddOrUpdate(p => new { p.year, p.month }, s));
            context.SaveChanges();
           

        }
    }
}
