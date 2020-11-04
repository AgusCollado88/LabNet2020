using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    interface ILogic<T>
    {
        List<T> GetAll();
        T GetOne(int id);
        T Insert(T entity);
        T Update(T entity);
        T Delete(T entity);
        
    }
}
