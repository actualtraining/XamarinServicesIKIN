using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using XamarinServicesIKIN.Model;
using System.Net.Http;
using Newtonsoft.Json;

namespace XamarinServicesIKIN.Services
{
    public class TodoItemServices
    {
        private HttpClient _client;

        public TodoItemServices()
        {
            _client = new HttpClient();
        }
        public async Task<List<TodoItem>> GetAllTodoItem()
        {
            var strUri = new Uri(Path.Combine(Koneksi.RestUrl, "api/TodoItem"));
            var response = await _client.GetAsync(strUri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<TodoItem>>(content);
                return data;
            }
            else
            {
                throw new Exception("Error: " + response.StatusCode.ToString());
            }
        }
    }
}
