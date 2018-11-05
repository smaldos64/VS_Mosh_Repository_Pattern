using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mosh_Repository_Pattern.Models;
using Mosh_Repository_Pattern.Repository;

namespace Mosh_Repository_Pattern.Project_Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContext context) : base(context)
        {

        }

        public IEnumerable<Category> GetAllCategories()
        {
            return (DatabaseContext.Categories.ToList());
        }

        public Category GetCategoryByCategoryID(int id)
        {
            return (DatabaseContext.Categories.Find(id));
        }

        public DatabaseContext DatabaseContext
        {
            get { return Context as DatabaseContext;  }
            // Cast den nedarvede Context fra den generiske klasse Repository til DatabaseContext.
            // Ellers skulle vi have gentaget koden : Context as DatabaseContext i alle metoder i klassen her.
        }
    }
}
