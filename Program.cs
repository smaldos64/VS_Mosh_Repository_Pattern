using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mosh_Repository_Pattern.Models;
using Mosh_Repository_Pattern.Repository;
using Mosh_Repository_Pattern.Project_Repository;
using Mosh_Repository_Pattern.Project_UnitOfWork;
using Mosh_Repository_Pattern.Tools;

namespace Mosh_Repository_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var UnitOfWork_Object = new UnitOfWork(new DatabaseContext()))
            {
                Console.WriteLine("Eksempel 1");
                Product Product_Object = UnitOfWork_Object.Products.Get(1);
                Console.WriteLine("Product navn : " + Product_Object.ProductName);
                Console.WriteLine("Kategory Navn : " + Product_Object.Category.CategoryName);

                Console.WriteLine("");
                Console.WriteLine("Eksempel 2");
                Category Category_Object = UnitOfWork_Object.Categories.Get(6);
                Console.WriteLine("Kategori Navn : " + Category_Object.CategoryName);
                while (null != Category_Object.ParentCategoryID)
                {
                    Category_Object = Category_Object.ParentCategory;
                    Console.WriteLine("Kategori Navn : " + Category_Object.CategoryName);
                }

                Console.WriteLine("");
                Console.WriteLine("Eksempel 3");
                Category Category_ObjectTop = UnitOfWork_Object.Categories.Get(1);
                List<Category> CategoryList = RecursiveFunction.GetAllCategoriesUnderMainCategory(Category_ObjectTop);
                foreach (Category CategoryObject in CategoryList)
                {
                    Console.WriteLine("Kategori Navn : " + CategoryObject.CategoryName);
                }

                Console.WriteLine("");
                Console.WriteLine("Eksempel 4");
                Product_Object.ProductName = "Modificeret";
                UnitOfWork_Object.Complete();

                Console.WriteLine("");
                Console.WriteLine("Eksempel 5");
                Product Product_Object1 = new Product();
                Product_Object1.ProductName = "Test det her";
                Product_Object1.CategoryID = 1;
                UnitOfWork_Object.Products.Add(Product_Object1);
                UnitOfWork_Object.Complete();

                Console.WriteLine("");
                Console.WriteLine("Eksempel 6");
                int StartValue = 6;
                do
                {
                    Product_Object1 = UnitOfWork_Object.Products.Get(StartValue);
                    StartValue++;
                } while (null == Product_Object1);
                
                UnitOfWork_Object.Products.Remove(Product_Object1);
                UnitOfWork_Object.Complete();
                Console.WriteLine("Slettet Produkt med ProductID " + StartValue);

                Console.ReadLine();
            }
        }
    }
}
