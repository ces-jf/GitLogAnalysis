using GitLogAnalysis.Core.SharedKernel.Interfaces.UoW;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitLogAnalysis.Infra.Data.UoW
{
    public class UnityOfWork : IUnitOfWork
    {
        protected readonly DataContext DbContext;
        public UnityOfWork(DataContext dbContext)
        {
            DbContext = dbContext;
        }
        public bool Commit()
        {
            try
            {
                if (DbContext.ChangeTracker.Entries().Any(e =>
                    e.State == EntityState.Added || e.State == EntityState.Deleted || e.State == EntityState.Modified))
                {
                    Log.Information("Commit Done");
                    return DbContext.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception e)
            {
                Log.Error($"Commit Failed. The reason is {e.Message}");
                throw;
            }
        }
    }
}
