using System;
using System.Collections.Generic;
using System.Text;
using HotelGuide.DataAccess;
using HotelGuide.Entity.Model;

namespace HotelGuide.Business
{
  public  class UserBusiness
    {
        public static User Login(string username, string password)
        {
            UserRepository repository=new UserRepository();

            return repository.Login(username, password);
        }
    }
}
