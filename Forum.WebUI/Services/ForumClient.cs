using Forum.Service.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.WebUI.Services
{
    public class ForumClient:IForumClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ForumClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));    
        }
        public async Task<IReadOnlyCollection<CreatePostDto>> GetRepositories(CancellationToken cancellationToken)
        {
            var httpClient = _httpClientFactory.CreateClient("GitHub");
            var result = await httpClient.GetStringAsync("").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<CreatePostDto>>(result);
        }
    }
}
