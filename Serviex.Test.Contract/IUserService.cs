using Serviex.Test.Entity;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Serviex.Test.Contract
{
    [ServiceContract]
    public interface IUserService
    {
        [Description("Servicio con el cual se obtiene el listado de usuarios")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getusers", BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))]
        IEnumerable<User_test> GetUserList();

        [Description("Servicio con el cual se obtiene un suario por su id")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getuser/{id}", BodyStyle = WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))]
        User_test GetUser(string id);

        [Description("Servicio para realizar el insert de un usuario")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "/createuser", BodyStyle = WebMessageBodyStyle.Bare)]
        User_test CreateUser(User_test user);

        [Description("Servicio para actualizar un usuario")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "PUT", UriTemplate = "/updateuser", BodyStyle = WebMessageBodyStyle.Bare)]
        User_test UpdateUser(User_test user);

        [Description("Servicio para eliminar un usuario por id")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "DELETE", UriTemplate = "/deleteuser/{id}", BodyStyle = WebMessageBodyStyle.Bare)]
        bool DeleteUser(string id);

    }
}
