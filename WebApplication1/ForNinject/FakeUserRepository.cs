using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ForNinject
{
    public class FakeUserRepository: IUserRepository
    {
        private Users[] fakeUsers =
        {
            new Users() { ID_User = 1, Name = "ИмяПользователя1", Nickname = "Пользователь1", MobileNumber = "МобильныйНомер1", Email = "Email1", Checker = false, Password = "Пароль1"},
            new Users() { ID_User = 2, Name = "ИмяПользователя2", Nickname = "Пользователь2", MobileNumber = "МобильныйНомер2", Email = "Email2", Checker = false, Password = "Пароль2"},
            new Users() { ID_User = 3, Name = "ИмяПользователя3", Nickname = "Пользователь3", MobileNumber = "МобильныйНомер3", Email = "Email3", Checker = false, Password = "Пароль3"},
            new Users() { ID_User = 4, Name = "ИмяПользователя4", Nickname = "Пользователь4", MobileNumber = "МобильныйНомер4", Email = "Email4", Checker = false, Password = "Пароль4"},
            new Users() { ID_User = 5, Name = "ИмяПользователя5", Nickname = "Пользователь5", MobileNumber = "МобильныйНомер5", Email = "Email5", Checker = false, Password = "Пароль5"},
            new Users() { ID_User = 6, Name = "ИмяПользователя6", Nickname = "Пользователь6", MobileNumber = "МобильныйНомер6", Email = "Email6", Checker = false, Password = "Пароль6"},
            new Users() { ID_User = 7, Name = "ИмяПользователя7", Nickname = "Пользователь7", MobileNumber = "МобильныйНомер7", Email = "Email7", Checker = false, Password = "Пароль7"}
        };

        public IEnumerable<Users> GetUsers()
        {
            return fakeUsers;
        }
    }
}