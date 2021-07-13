using FitnessClubCP.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClubCP.DB
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
            : base("FitnesClubConnection"){}
        public DbSet<User> Users { get; set; }
        public DbSet<Trener> Treners { get; set; }
        public DbSet<Abonements> Abonements { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
