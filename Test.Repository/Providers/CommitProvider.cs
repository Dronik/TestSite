using System;
using Test.Model.Interfaces;
using Test.Model.Interfaces.IProviders;

namespace Test.DataProvider.Providers
{
    internal class CommitProvider : ICommitProvider
    {
        private readonly IDatabaseFactory _dbFactory;
        private event Action OnCommitFinished;

        private bool _isCommitedOnce = false;

        public CommitProvider(IDatabaseFactory dbFactory)
        {
            if (dbFactory != null)
                _dbFactory = dbFactory;
        }

        public void Commit()
        {
            if (_isCommitedOnce)
            {
                //     Logger.WriteDebugInfo(string.Format("Only one commit is allowed.{0}{1}", Environment.NewLine, Environment.StackTrace));
            }

            var dbContext = _dbFactory.GetContext();
            //   dvsContext.SetChangeTrackingManager(_changeTrackingManager);
            dbContext.SaveChanges();

            _isCommitedOnce = true;
            if (OnCommitFinished != null)
            {
                OnCommitFinished();
            }
        }

        private bool disposed = false;



        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbFactory.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void AddToExecuteOnCommit(Action action)
        {
            Action handler = null;
            handler = () =>
            {
                action();
                OnCommitFinished -= handler;
            };
            OnCommitFinished += handler;
        }
    }
}
