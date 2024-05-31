using CGC.Domain.Aggregates.WIT;
using CGC.Domain.Base;
using CGC.Domain.Models.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC.DataAccess
{
    public class WorkItemContext : DbContext
    {
        public WorkItemContext(DbContextOptions options) : base(options) { }
        public DbSet<WorkItem> WorkItem { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Domain.Aggregates.WIT.Links> Links { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WorkItem>().OwnsOne(t => t.Fields);
            modelBuilder.Entity<User>().OwnsOne(s => s.Links, l => l.OwnsOne(a => a.Avatar));
            
        }
    }
}
