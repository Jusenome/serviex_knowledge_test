using Serviex.Test.Entity;
using System.Collections.Generic;

namespace Serviex.Test.Repository
{
    public interface IUserRepository
    {
        User_test CreateUser(User_test user);

        bool DeleteUser(string id);

        IEnumerable<User_test> GetUserList();

        User_test GetUser(string id);

        User_test UpdateUser(User_test user);
    }
}
