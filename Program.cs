using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mosh_Repository_Pattern.Models;
using Mosh_Repository_Pattern.Repository;
using Mosh_Repository_Pattern.Project_Repository;
using Mosh_Repository_Pattern.Project_UnitOfWork;

namespace Mosh_Repository_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var UnitOfWork_Object = new UnitOfWork(new DatabaseContext()))
            {

            }
        }
    }
}
