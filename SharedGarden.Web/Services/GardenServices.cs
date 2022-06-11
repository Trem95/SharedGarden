using Newtonsoft.Json;
using SharedGarden.Web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace SharedGarden.Web.Services
{
    public class GardenServices
    {
        public const string baseAddress = "https://localhost:7103/api/";
        public static IList<GardenModel> GetAllGardens()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                HttpResponseMessage httpResponseMessage = client.GetAsync("Gardens").Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

                GardenModelsVm listGarden = JsonConvert.DeserializeObject<GardenModelsVm>(json);
                
                return listGarden.GardenList;
            }
        }

        public static GardenModel GetGardenById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                HttpResponseMessage httpResponseMessage = client.GetAsync($"Gardens/{id}").Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                GardenModel garden = JsonConvert.DeserializeObject<GardenModel>(json);

                return garden;
            }
        }
    }
}
