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

        public async void PostQuestionData(Questions data)
        {
            PostQuestion postQuestion = new(data.Date, data.Headline, data.Question, data.User.Name, data.Category.Name);
            string url = $"{baseAPI}question/";
            await http.PostAsJsonAsync(url, postQuestion);
        }

        private record PostQuestion(DateTime date, string headline, string question, string name, string category);
       
    }


}

