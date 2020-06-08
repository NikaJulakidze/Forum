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
        Task<ApiCallResult<TResponse>> DeleteAsync<TResponse>(string url);
        Task<ApiCallResult<TResponse>> GetAsync<TResponse>(string url);
        Task<ApiCallResult<TResponse>> PostAsync<TResponse>(string url, object data);
        Task<ApiCallResult<TResponse>> PutAsync<TResponse>(string url, object data);
    }
}
