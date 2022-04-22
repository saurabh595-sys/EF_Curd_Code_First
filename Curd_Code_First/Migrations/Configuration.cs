namespace Curd_Code_First.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Curd_Code_First.Models.Contex>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Curd_Code_First.Models.Contex";
        }

        protected override void Seed(Curd_Code_First.Models.Contex context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
