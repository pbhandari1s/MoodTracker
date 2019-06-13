using MoodTracker.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Data
{
    public class MoodTrackerContext : DbContext
    {
        public MoodTrackerContext() : base("MoodTracker")
        {
            //Database.SetInitializer<CoalitionManagerContext>(new CoalitionManagerDBInitializer<CoalitionManagerContext>());
            //Database.Initialize(force: true);
        }

        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
