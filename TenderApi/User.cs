using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using TenderApi.Model;
using Newtonsoft.Json;

namespace TenderApi
{
    public partial class TenderApi
    {
        /// <summary>
        /// Gets all the users
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            return GetCollection<User>("users", "users");            
        }        

        /// <summary>
        /// Finds a user by their email address
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public User FindUser(string email)
        {
            var request = new RestRequest
                              {
                                  Resource = "users",
                                  RootElement = "users",
                                  Method = Method.GET,
                                  RequestFormat = RestSharp.DataFormat.Json
                              };
            request.AddParameter("email", email);

            return Execute<List<User>>(request)[0];
        }

        /// <summary>
        /// Checks to see if the authentication is valid
        /// </summary>
        /// <returns></returns>
        public bool AuthenticationIsValid()
        {
            var request = new RestRequest {Method = Method.GET, RequestFormat = RestSharp.DataFormat.Json};

            IRestResponse res = Execute(request);
            return res.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Creates a user with the following information.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="passwordConfirmation"></param>
        /// <param name="name"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public User CreateUser(string email, string password, string passwordConfirmation, string name=null, string title=null)
        {
            var request = new RestRequest
                              {
                                  Resource = "users",
                                  Method = Method.POST,
                                  RequestFormat = RestSharp.DataFormat.Json
                              };
            request.AddParameter("email", email);
            request.AddParameter("password", password);
            request.AddParameter("password_confirmation", passwordConfirmation);
            request.AddParameter("name", name);
            request.AddParameter("title", title);

            return  Execute<User>(request);
        }

        public User CreateUser(string email, string site, string ssoKey)
        {
            string ssoToken = GenerateSsoToken(email, site, ssoKey);

            var request = new RestRequest
            {
                Resource = "/profile?sso=" + ssoToken,
                Method = Method.GET,
            };

            return Execute<User>(request);
        }

        public User AssignCompany(int userId, int companyId)
        {
            var request = new RestRequest
            {
                Resource = string.Format("users/{0}", userId),
                Method = Method.PUT,
                RequestFormat = RestSharp.DataFormat.Json,
            };

            request.AddParameter("company_id", companyId);

            return Execute<User>(request);
        }
    }
    
}
