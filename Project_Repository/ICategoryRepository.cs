using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mosh_Repository_Pattern.Models;
using Mosh_Repository_Pattern.Repository;

namespace Mosh_Repository_Pattern.Project_Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryByCategoryID(int id);
    }
}
