using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ForNinject
{
    public class UserRepository: IUserRepository
    {
        public IEnumerable<Users> GetUsers()
        {
            var contex = new CinemaddictEntities2();
            return contex.Users.ToList();
        }
    }
}