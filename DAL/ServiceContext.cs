using Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ServiceContext : IdentityDbContext<Person>
    {
        public ServiceContext() : base("ServiceContext")
        {

        }
        public virtual DbSet<LiveMessage> LiveMessages { get; set; }
        public virtual DbSet<Fault> Faults { get; set; }

        public static ServiceContext Create()
        {
            return new ServiceContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LiveMessage>().HasKey(x => x.Id);
            modelBuilder.Entity<Fault>().HasKey(x => x.Id);

            modelBuilder.Entity<Person>()
                .HasMany(x => x.Faults)
                .WithRequired(x => x.Person);
            modelBuilder.Entity<Person>()
                .HasMany(x => x.LiveMessages)
                .WithOptional(x => x.Person);


            base.OnModelCreating(modelBuilder);
        }
    }
}
