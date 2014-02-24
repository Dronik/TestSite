using System;

namespace Test.Model.Interfaces.IProviders
{
    public interface ICommitProvider : IDisposable
    {
        void Commit();
        void AddToExecuteOnCommit(Action action);
    }
}
