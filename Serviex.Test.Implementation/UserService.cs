using Serviex.Test.Contract;
using Serviex.Test.Entity;
using Serviex.Test.Facade;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Serviex.Test.Implementation
{
    public class UserService : IUserService
    {
        public User_test CreateUser(User_test user)
        {
            try
            {
                using (UserFacade User = new UserFacade())
                {
                    return User.CreateUser(user);
                }

            }
            catch (Exception ex)
            {
                throw new FaultException<Error>(new Error() { Description = "Exception administrada por el servicio", Message = ex.Message });
            }
        }

        public bool DeleteUser(string id)
        {
            try
            {
                using (UserFacade User = new UserFacade())
                {
                    return User.DeleteUser(id);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<Error>(new Error() { Description = "Exception administrada por el servicio", Message = ex.Message });
            }
        }

        public IEnumerable<User_test> GetUserList()
        {
            try
            {
                using (UserFacade Users = new UserFacade())
                {
                    return Users.GetUserList();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<Error>(new Error() { Description = "Exception administrada por el servicio", Message = ex.Message });
            }
        }

        public User_test GetUser(string id)
        {
            try
            {
                using (UserFacade User = new UserFacade())
                {
                    return User.GetUser(id);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<Error>(new Error() { Description = "Exception administrada por el servicio", Message = ex.Message });
            }
        }

        public User_test UpdateUser(User_test user)
        {
            try
            {
                using (UserFacade User = new UserFacade())
                {
                    return User.UpdateUser(user);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<Error>(new Error() { Description = "Exception administrada por el servicio", Message = ex.Message });
            }
        }
    }
}
