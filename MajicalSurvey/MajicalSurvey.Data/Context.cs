using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data
{
    public class Context : DbContext
    {
        public DbSet<Surveys> Surveys { get; set; }
        public DbSet<Questions> Questions { get; set;}
        public DbSet<Answers> Answers { get; set; }

        public Context():base("localsql")
        {

        }
    }
}
