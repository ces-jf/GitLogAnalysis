using GitLogAnalysis.Core.Aggregates.GitAgg.Entities;
using GitLogAnalysis.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitLogAnalysis.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ReleaseData> ReleasesData { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReleaseDataMap());
            //modelBuilder.ApplyConfiguration(new ProfileMap());
            //modelBuilder.ApplyConfiguration(new FunctionalityMap());
            //modelBuilder.ApplyConfiguration(new ProfileFunctionalityMap());
            //modelBuilder.ApplyConfiguration(new EventMap());
            //modelBuilder.ApplyConfiguration(new CityMap());
            //modelBuilder.ApplyConfiguration(new EventTypeMap());
            //modelBuilder.ApplyConfiguration(new SubscriptionMap());
        }
    }

}
