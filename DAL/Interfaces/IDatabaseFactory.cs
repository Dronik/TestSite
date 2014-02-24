using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model.Interfaces
{
    public interface IDatabaseFactory : IDisposable
    {
        IDatabaseContext GetContext();
    }
}
