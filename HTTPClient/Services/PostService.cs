using HTTPClient.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HTTPClient.Services
{
    internal class PostService
    {
        private HttpClient httpClient;
        private Post post;
        private List<Post> posts;
        private JsonSerializerOptions jsonSerializerOptions;
        public PostService()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions{
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<Post>> getPosts()
        {
            Uri uri = new Uri("https://jsonplaceholder.typicode.com/posts");
            List<Post> items = new List<Post>();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    items = JsonSerializer.Deserialize<List<Post>>(content);
                }
            }
            catch(Exception ex) {
                Debug.WriteLine(ex.Message);            
            }
            return items;
        }
    }
}
