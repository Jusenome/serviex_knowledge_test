using Serviex.Test.Entity;
using Serviex.Test.Repository;
using System;
using System.Collections.Generic;

namespace Serviex.Test.Facade
{
    public class UserFacade : IDisposable
    {
        public User_test CreateUser(User_test user)
        {
            IUserRepository User = new UserRepository();
            return User.CreateUser(user);
        }

        public bool DeleteUser(string id)
        {
            IUserRepository User = new UserRepository();
            return User.DeleteUser(id);
        }

        public IEnumerable<User_test> GetUserList()
        {
            IUserRepository Users = new UserRepository();
            return Users.GetUserList();
        }

        public User_test GetUser(string id)
        {
            IUserRepository Users = new UserRepository();
            return Users.GetUser(id);
        }

        public User_test UpdateUser(User_test user)
        {
            IUserRepository User = new UserRepository();
            return User.UpdateUser(user);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
