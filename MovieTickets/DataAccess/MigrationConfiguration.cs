using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public sealed class MigrationConfiguration<TContext> : DbMigrationsConfiguration<TContext> where TContext : DbContext
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TContext context)
        {
            base.Seed(context);
        }
    }
}
