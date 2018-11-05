using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mosh_Repository_Pattern.Models;

namespace Mosh_Repository_Pattern.Tools
{
    public class RecursiveFunction
    {
        private static List<Category> CategoryList = new List<Category>();

        public static List<Category> GetAllCategoriesUnderMainCategory(Category Category_Object)
        {
            CategoryList.Clear();
            Category Category_ObjectWork = Category_Object;

            while (null != Category_ObjectWork.ParentCategoryID)
            {
                Category_ObjectWork = Category_ObjectWork.ParentCategory;
                CategoryList.Add(Category_ObjectWork);
            }
            CategoryList.Reverse();
            CategoryList.Add(Category_Object);

            if (Category_Object.ChildCategories.Count > 0)
            {
                GetAllCategories(Category_Object);
            }

            return (CategoryList);
        }

        private static void GetAllCategories(Category Category_Object)
        {
            foreach (Category item in Category_Object.ChildCategories)
            {
                CategoryList.Add(item);
                if (item.ChildCategories.Count > 0)
                {
                    GetAllCategories(item);
                }
            }
        }
    }
}
