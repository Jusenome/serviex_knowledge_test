using Dapper;
using Serviex.Test.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Serviex.Test.Repository
{
    public class UserRepository : IUserRepository
    {
        public User_test CreateUser(User_test user)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionRepository.GetConnectionString()))
            {
                connection.Open();
                var parameters = new DynamicParameters();

                parameters.Add("name", user.Name);
                parameters.Add("date_of_birth", user.Date_of_birth);
                parameters.Add("gender", user.Gender);
                parameters.Add("id", user.Id, DbType.Int32, ParameterDirection.Output);

                var result = connection.ExecuteScalar("dbo.sp_user_create", param: parameters, commandType: CommandType.StoredProcedure);
                user.Id = parameters.Get<Int32>("id");
                return user;
            }
        }

        public bool DeleteUser(string id)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionRepository.GetConnectionString()))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("id", id);
                var result = connection.Execute("dbo.sp_user_delete", param: parameter, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public IEnumerable<User_test> GetUserList()
        {
            using (IDbConnection connection = new SqlConnection(ConnectionRepository.GetConnectionString()))
            {
                connection.Open();
                var Users = connection.Query<User_test>("dbo.sp_user_list", commandType: CommandType.StoredProcedure);
                return Users;
            }
        }

        public User_test GetUser(string id)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionRepository.GetConnectionString()))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("id", id);
                var User = connection.QuerySingle<User_test>("dbo.sp_user_getuser", param: parameter, commandType: CommandType.StoredProcedure);
                return User;
            }
        }

        public User_test UpdateUser(User_test user)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionRepository.GetConnectionString()))
            {
                connection.Open();
                var parameters = new DynamicParameters();

                parameters.Add("id", user.Id);
                parameters.Add("name", user.Name);
                parameters.Add("date_of_birth", user.Date_of_birth);
                parameters.Add("gender", user.Gender);

                var result = connection.Execute("dbo.sp_user_update", param: parameters, commandType: CommandType.StoredProcedure);
                
                return result > 0 ? user : new User_test();
            }
        }
    }
}
