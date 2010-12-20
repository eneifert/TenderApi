using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace TenderApi
{
    public partial class TenderApi
    {
        private const string BaseUrl = "http://api.tenderapp.com/";
		private RestClient _client;        

        /// <summary>
        /// Constructor that uses BasicHttpAuthentication.
        /// </summary>
        /// <param name="site"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        public TenderApi(string site, string user, string password)
        {
            setUpDefaults(site);
            _client.Authenticator = new HttpBasicAuthenticator(user, password);
        }

        /// <summary>
        /// Constructor that uses the api key for authentication (recommended).
        /// </summary>
        /// <param name="site"></param>
        /// <param name="apiKey"></param>
		public TenderApi(string site, string apiKey)
		{
		    setUpDefaults(site);

            _client.AddDefaultParameter("auth", apiKey);            
		}

        void setUpDefaults(string site)
        {
            _client = new RestClient(BaseUrl + site + "/");

            _client.AddHandler("application/json", new RestSharp.Deserializers.JsonDeserializer());
            _client.AddHandler("application/vnd.tender-v1+json", new RestSharp.Deserializers.JsonDeserializer());    
        }

		public T Execute<T>(RestRequest request) where T : new()
		{
			var response = _client.Execute<T>(request);
			return response.Data;
		}

		public RestResponse Execute(RestRequest request)
		{
			return _client.Execute(request);
		}

        /// <summary>
        /// Gets the Collection
        /// </summary>
        /// <returns></returns>
        public List<T> GetCollection<T>(string resource, string rootElement)
        {
            var request = new RestRequest
            {
                Method = Method.GET,
                RequestFormat = RestSharp.DataFormat.Json,
                Resource = resource,
                RootElement = rootElement
            };

            return Execute<List<T>>(request);
        }
    }
}
