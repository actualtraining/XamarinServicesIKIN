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

        public async Task TambahTodoItem(TodoItem todoItem)
        {
            var strUri = new Uri(Path.Combine(Koneksi.RestUrl, "api/TodoItem"));
            var newItem = JsonConvert.SerializeObject(todoItem);
            var content = new StringContent(newItem, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await _client.PostAsync(strUri, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error : Data gagal ditambahkan, status:"
                    + response.StatusCode);
            }
        }

        public async Task EditTodoItem(TodoItem todoItem)
        {
            var strUri = new Uri(Path.Combine(Koneksi.RestUrl, "api/TodoItem/"+todoItem.ID));
            var newItem = JsonConvert.SerializeObject(todoItem);
            var content = new StringContent(newItem, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await _client.PutAsync(strUri, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error : Data gagal diupdate, status:"
                    + response.StatusCode);
            }
        }
    }
}
