using Serviex.Test.WebTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Serviex.Test.WebTest.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        //public ActionResult Index()
        //{
        //    return Create();
        //}


        public ActionResult Create()
        {
            var list = new List<string>() { "F", "M" };
            ViewBag.list = list;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserViewModel user)
        {
            if (!ModelState.IsValid)
                return View(user);


            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(UserViewModel));
                MemoryStream memory = new MemoryStream();
                json.WriteObject(memory, user);
                string data = Encoding.UTF8.GetString(memory.ToArray(), 0, (int)memory.Length);

                HttpResponseMessage response = await client.PostAsync("WcfServiceUser/UserService.svc/rest/createuser", new StringContent(data, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Create");
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("WcfServiceUser/UserService.svc/rest/getusers");

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStreamAsync().Result;
                    DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(List<UserViewModel>));
                    List<UserViewModel> responseData = obj.ReadObject(result) as List<UserViewModel>;
                    return View(responseData);
                }
                else
                {
                    return View();
                }
            }
        }

        
        public async Task<ActionResult> Edit(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("WcfServiceUser/UserService.svc/rest/getuser/" + id);

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStreamAsync().Result;
                    DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(UserViewModel));
                    UserViewModel responseData = obj.ReadObject(result) as UserViewModel;
                    ViewBag.list = new List<string>() { responseData.Gender, responseData.Gender == "M" ? "F" : "M" };
                    return View(responseData);
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UserViewModel user)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(UserViewModel));
                MemoryStream memory = new MemoryStream();
                json.WriteObject(memory, user);
                string data = Encoding.UTF8.GetString(memory.ToArray(), 0, (int)memory.Length);

                HttpResponseMessage response = await client.PutAsync("WcfServiceUser/UserService.svc/rest/updateuser", new StringContent(data, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("List");
            }
            return View();
        }

        
        public async Task<ActionResult> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("WcfServiceUser/UserService.svc/rest/getuser/" + id);

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStreamAsync().Result;
                    DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(UserViewModel));
                    UserViewModel responseData = obj.ReadObject(result) as UserViewModel;
                    return View(responseData);
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(UserViewModel user)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.DeleteAsync("WcfServiceUser/UserService.svc/rest/deleteuser/" + user.Id);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    return View();
                }
            }
        }
    }
}