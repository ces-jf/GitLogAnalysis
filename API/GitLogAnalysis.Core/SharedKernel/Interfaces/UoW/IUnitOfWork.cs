using System;
using System.Collections.Generic;
using System.Text;

namespace GitLogAnalysis.Core.SharedKernel.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}
