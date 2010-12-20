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

            RestResponse res = Execute(request);
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

        
       



        public static class Users
        {
            public static IList<User> Get()
            {

                return null;
            }
        }

        public static class Discussions
        {
            public static IList<User> Get()
            {
                return null;
            }
        }
       
    }
    
}
