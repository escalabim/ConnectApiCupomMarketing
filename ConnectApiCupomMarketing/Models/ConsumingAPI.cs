using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using ConectApiCupomMarketing.Models;

namespace ConectApiCupomMarketing.Controllers
{
    public class ConsumingAPI
    {
        /// <summary>
        /// Realiza o GET
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<string> Get(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var result = await client.GetAsync("");
                string data = await result.Content.ReadAsStringAsync();
                return data;
            }

        }

        /// <summary>
        /// Realiza o POST 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public static async Task<string> Post(string url, Object obj)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage data = await client.PostAsJsonAsync("", obj);
                return await data.Content.ReadAsStringAsync();
            }

        }


    }

}