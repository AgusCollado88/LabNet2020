using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CategoriesLogic
    {
        public List<Categories> Categories()
        {
            NorthwindContext context = new NorthwindContext();
            return context.Categories.ToList();
        }

    }
}
