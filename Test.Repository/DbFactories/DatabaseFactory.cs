using System;
using System.Collections.Generic;
using System.Data.Entity;
using Test.DataProvider.DbContexts;
using Test.Model.Interfaces;

namespace Test.DataProvider.DbFactories
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private static readonly object _lockObj = new object();
        private Dictionary<Type, DbContext> _dataContexts = new Dictionary<Type, DbContext>();
        private int _disposeCount = 0;

        public DatabaseFactory()
        {

        }

        public IDatabaseContext GetContext()
        {
            if (!_dataContexts.ContainsKey(typeof(TestDataContext)))
            {
                lock (_lockObj)
                {
                    if (!_dataContexts.ContainsKey(typeof(TestDataContext)))
                    {
                        DbContext dataContext;
                       // if (typeof(TContext) == typeof(TestDataContext))
                            dataContext = new TestDataContext();
                        //else if (typeof(TContext) == typeof(TaskQueueContext))
                        //    dataContext = new TaskQueueContext();
                        //else
                        //    throw new NotSupportedException(typeof(TContext).ToString());

                            _dataContexts.Add(typeof(TestDataContext), dataContext);
                    }
                }
            }
            return (IDatabaseContext)_dataContexts[typeof(TestDataContext)];
        }

        protected override void DisposeCore()
        {
            _disposeCount++;
            if (_disposeCount > 1)
            {
             //   Logger.WriteError(new Exception(string.Format("DB factory was disposed {0} times", _disposeCount)));
            }

            if (_dataContexts != null)
            {
                foreach (var dataContext in _dataContexts)
                    dataContext.Value.Dispose();
                _dataContexts.Clear();
            }
        }
    }

    public class Disposable : IDisposable
    {
        private bool isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        protected virtual void DisposeCore()
        {
        }
    }
}
