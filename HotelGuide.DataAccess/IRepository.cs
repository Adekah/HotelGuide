using System;
using System.Collections.Generic;
using System.Text;
using HotelGuide.Entity.Model;

namespace HotelGuide.DataAccess
{
    public interface IRepository<T>
    {
        HotelsViewModel Get(int id);
        List<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);

    }
}
