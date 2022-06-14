using Newtonsoft.Json;
using SharedGarden.Web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SharedGarden.Web.Services
{
    public class UserServices
    {
        public const string baseAddress = "https://localhost:7103/api/";
        public static UserModel GetUserByEmail(string email)
        {
            using (HttpClient client = new HttpClient())
            {
                UserModel userModel;
                client.BaseAddress = new Uri(baseAddress);
                HttpResponseMessage httpResponseMessage = client.GetAsync($"Users/Login/{email}").Result;
                try
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    userModel = JsonConvert.DeserializeObject<UserModel>(json);

                }
                catch (Exception)
                {
                    return new UserModel
                    {
                        Id = -1
                    };
                }

                return userModel;
            }
        }

        public static int CreateNewUser(UserModel userModel)
        {
            if (userModel != null)
            {
                using (HttpClient client = new HttpClient())
                {
                    string resJson;
                    string userJson = JsonConvert.SerializeObject(userModel);
                    client.BaseAddress = new Uri(baseAddress);
                    HttpContent httpContent = new StringContent(userJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage httpResponseMessage = client.PostAsync("Users", httpContent).Result;
                    httpResponseMessage.EnsureSuccessStatusCode();
                    if (httpResponseMessage.Content != null)
                    {
                        resJson = httpResponseMessage.Content.ReadAsStringAsync().Result;

                        int newUserId;
                        if (int.TryParse(resJson, out newUserId))
                            return newUserId;

                    }
                }
            }
            return -1;
        }
    }
}
