﻿using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;
using ApiRest.Model;
using System.Threading.Tasks;
using ApiRest.Comun;

namespace ApiRest.Data
{
    public class RestServices : IRestServices
    {

        HttpClient _client;

        public RestServices()
        {
            _client = new HttpClient();
        }

        public List<TodoItems> Items { get; set; }


        public async Task<List<TodoItems>> GetData()
        {
            Items = new List<TodoItems>();

            var uri = new Uri(string.Format(Constants.TodoItemsUrl, string.Empty));

            try
            {
                var response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    Items = JsonConvert.DeserializeObject<List<TodoItems>>(content);
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Error {0}", ex.Message);
            }

            return Items;

        }

    }
}
