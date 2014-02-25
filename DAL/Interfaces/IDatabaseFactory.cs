using System;

namespace Test.Model.Interfaces
{
    public interface IDatabaseFactory : IDisposable
    {
        IDatabaseContext GetContext();
    }
}
