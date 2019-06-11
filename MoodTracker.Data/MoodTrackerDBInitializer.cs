using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Data
{
    public class MoodTrackerDBInitializer<T> : DropCreateDatabaseIfModelChanges<MoodTrackerContext>
    {
        protected override void Seed(MoodTrackerContext context)
        {
            base.Seed(context);
        }
    }
}
