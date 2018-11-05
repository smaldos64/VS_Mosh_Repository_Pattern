using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mosh_Repository_Pattern.Models;
using Mosh_Repository_Pattern.Project_Repository;

namespace Mosh_Repository_Pattern.Project_UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            this._context = context;
            Products = new ProductRepository(_context);
            Categories = new CategoryRepository(_context);
        }

        public IProductRepository Products { get; private set; }
        public ICategoryRepository Categories { get; private set; }

        public int Complete()
        {
            return (_context.SaveChanges());
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
