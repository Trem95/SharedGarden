using Newtonsoft.Json;
using SharedGarden.Web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace SharedGarden.Web.Services
{
    public class ReservationServices
    {
        public const string baseAddress = "https://localhost:7103/api/";

        public static IList<ReservationModel> GetReservationsByUserId(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                HttpResponseMessage httpResponseMessage = client.GetAsync($"Reservations/UserId/{id}").Result;
                try
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException ex)
                {
                    return new List<ReservationModel>();
                }
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ReservationsModelsVm listRes = JsonConvert.DeserializeObject<ReservationsModelsVm>(json);

                return listRes.ReservationList;
            }
        }
    }
}
