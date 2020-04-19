using Forum.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Forum.WebUI.Services
{
    public interface IApiCall
    {
        Task<string> GetAsStringAsync(string url);
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync<TData>(string url, TData data);
    }
}
