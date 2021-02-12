using Microsoft.AspNetCore.WebUtilities;

namespace Forum.Service.Uri
{
    public class UriService:IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public System.Uri GetPagedUri(int pageNumber, int pageSize, string route)
        {
            var _enpointUri = new System.Uri(string.Concat(_baseUri, route));
            var modifiedUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "pageNumber", pageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", pageSize.ToString());
            return new System.Uri(modifiedUri);
        }
    }
}
