using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mosh_Repository_Pattern.Models;
using Mosh_Repository_Pattern.Repository;

namespace Mosh_Repository_Pattern.Project_Repository
{
    class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext context) : base(context)
        {

        }

        public IEnumerable<Product> GetAllProducts()
        {
            return (DatabaseContext.Products.ToList());
        }

        public Product GetProductByProductID(int id)
        {
            return (DatabaseContext.Products.Find(id));
        }

        public DatabaseContext DatabaseContext
        {
            get { return Context as DatabaseContext; }
            // Cast den nedarvede Context fra den generiske klasse Repository til DatabaseContext.
            // Ellers skulle vi have gentaget koden : Context as DatabaseContext i alle metoder i klassen her.
        }
    }
}
