using Forum.Service.Dto;
using Forum.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Forum.WebUI.Services
{
    public interface IApiCallService
    {
        Task<string> GetAsStringAsync(string url);
        Task<HttpResponseMessage> GetAsync(string url);
        Task<ApiCallResult<TResponse>> PostAsync<TResponse>(string url, object data);
    }
}
