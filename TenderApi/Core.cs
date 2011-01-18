using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Contrib;

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

        public static string GenerateSsoToken(string email, string site, string apiKey)
        {
            var userDetails = JsonConvert.SerializeObject(new { email, expires = DateTime.Now.AddDays(1).ToString("ddd MMM d HH:mm:ss UTC yyyy") }, Formatting.None);

            string initVector = "OpenSSL for Ruby"; // DO NOT CHANGE

            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] keyBytesLong;

            using (SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider())
            {
                keyBytesLong = sha.ComputeHash(Encoding.UTF8.GetBytes(apiKey + site));
            }
            byte[] keyBytes = new byte[16];
            Array.Copy(keyBytesLong, keyBytes, 16);

            byte[] textBytes = Encoding.UTF8.GetBytes(userDetails);
            for (int i = 0; i < 16; i++)
            {
                textBytes[i] ^= initVectorBytes[i];
            }

            // Encrypt the string to an array of bytes
            byte[] encrypted = EncryptStringToBytesAes(textBytes, keyBytes, initVectorBytes);
            string encoded = Convert.ToBase64String(encrypted);

            return HttpUtility.UrlEncode(encoded);
        }

        static byte[] EncryptStringToBytesAes(byte[] textBytes, byte[] Key, byte[] IV)
        {
            // Declare the stream used to encrypt to an in memory
            // array of bytes and the RijndaelManaged object
            // used to encrypt the data.
            using (MemoryStream msEncrypt = new MemoryStream())
            using (RijndaelManaged aesAlg = new RijndaelManaged())
            {
                // Provide the RijndaelManaged object with the specified key and IV.
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.KeySize = 128;
                aesAlg.BlockSize = 128;
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                // Create an encrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor();

                // Create the streams used for encryption.
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    csEncrypt.Write(textBytes, 0, textBytes.Length);
                    csEncrypt.FlushFinalBlock();
                }

                byte[] encrypted = msEncrypt.ToArray();
                // Return the encrypted bytes from the memory stream.
                return encrypted;
            }
        }
    }
}
