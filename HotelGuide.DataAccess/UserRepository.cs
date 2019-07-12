using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelGuide.Entity.Model;

namespace HotelGuide.DataAccess
{
  public  class UserRepository : IRepository<User>
    {

        public User Login(string username, string password)
        {
            var context=new HotelDBContext();

            var _user = context.User.Where(x => x.UserName == username && x.Password == password).SingleOrDefault();
            return _user;
        }

        public HotelsViewModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(User entity)
        {

            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
