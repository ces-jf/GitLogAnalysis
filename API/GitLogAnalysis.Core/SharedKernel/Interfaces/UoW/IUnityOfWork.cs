using System;
using System.Collections.Generic;
using System.Text;

namespace GitLogAnalysis.Core.SharedKernel.Interfaces.UoW
{
    public interface IUnityOfWork
    {
        bool Commit();
    }
}
