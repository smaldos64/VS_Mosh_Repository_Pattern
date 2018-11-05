using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mosh_Repository_Pattern.Project_Repository;

namespace Mosh_Repository_Pattern.Project_UnitOfWork
{
    interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        // Bemærk at både Products og categories er defineret via deres Interfaces. Det er for at 
        // muliggøre test.
        int Complete();
    }
}
