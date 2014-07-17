using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TenderApi.Model;

namespace TenderApi
{
    public partial class TenderApi
    {
        /// <summary>
        /// Gets all the Comments for the discussion
        /// </summary>
        /// <returns></returns>
        public List<Comment> GetComments(int discussionID)
        {
            return GetCollection<Comment>(string.Format("discussions/{0}/comments", discussionID), "comments");
        }
    
        public Comment AddComment(int discussionId, Comment comment)
        {
            var request = new RestRequest
            {
                Method = Method.POST,
                RequestFormat = RestSharp.DataFormat.Json,
                Resource = string.Format("discussions/{0}/comments", discussionId),
            };

            request.AddBody(comment);

            return Execute<Comment>(request);
        }
    }
}
