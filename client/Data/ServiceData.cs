using System;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Model;

namespace TodoListBlazor.Data
{
    public class ServiceData
    {
        private readonly HttpClient http;
        private readonly IConfiguration configuration;
        private readonly string baseAPI = "";

        public ServiceData(HttpClient http, IConfiguration configuration)
        {
            this.http = http;
            this.configuration = configuration;
            baseAPI = configuration["base_api"];
        }

        public async Task<Questions[]> GetQuestionData()
        {
            string url = $"{baseAPI}questions/";
            return await http.GetFromJsonAsync<Questions[]>(url);
        }

        public async Task<Questions> GetQuestionDataSingle(int id)
        {
            string url = $"{baseAPI}questions/{id}";
            return await http.GetFromJsonAsync<Questions>(url);
        }

        //public async Task<Questions> PostQuestionData(int id)
        //{
        //    string url = $"{baseAPI}question/{id}";
        //    return await http.postFromJsonAsync<Questions>(url, postdata);
        //}


        //private record postdata(int id, string headline, )

    }


}

