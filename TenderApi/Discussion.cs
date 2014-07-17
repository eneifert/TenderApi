using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using TenderApi.Model;

namespace TenderApi
{
    public partial class TenderApi
    {
        
        /// <summary>
        /// Gets all the discussions
        /// </summary>
        /// <returns></returns>
        public List<Discussion> GetDiscussions()
        {
            return GetCollection<Discussion>("discussions", "discussions");           
        }

        /// <summary>
        /// Gets all the discussions by the state.
        /// States are: new, open, assigned, resolved, pending, deleted
        /// </summary>
        /// <returns></returns>
        public List<Discussion> GetDiscussionByState(string state)
        {

            var request = new RestRequest
            {
                Method = Method.GET,
                RequestFormat = RestSharp.DataFormat.Json,
                Resource = string.Format("discussions/{0}", state),
                RootElement = "discussions"
            };
            

            return Execute<List<Discussion>>(request);
        }

        /// <summary>
        /// Gets all the discussions for a user
        /// </summary>
        /// <returns></returns>
        public List<Discussion> GetDiscussionsForUser(int userID)
        {

            var request = new RestRequest
            {
                Method = Method.GET,
                RequestFormat = RestSharp.DataFormat.Json,                
                Resource = "discussions",
                RootElement = "discussions"
            };
            request.AddParameter("user_id", userID.ToString());

            return Execute<List<Discussion>>(request);
        }

        /// <summary>
        /// Gets all the discussions for an email
        /// </summary>
        /// <returns></returns>
        public List<Discussion> GetDiscussionsForEmail(string email)
        {
            return GetDiscussionsForUser(FindUser(email).GetUserID()); 
        }

        /// <summary>
        /// Creates a Discussion
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="title"></param>
        /// <param name="authorEmail"></param>
        /// <param name="authorName"></param>
        /// <param name="body"></param>
        /// <param name="isPublic"></param>
        /// <returns></returns>
        public bool CreateDiscussion(int categoryID, string title, string authorEmail, string authorName, string body, bool? isPublic=true)
        {

            var request = new RestRequest
            {
                Method = Method.POST,
                RequestFormat = RestSharp.DataFormat.Json,
                Resource = string.Format("categories/{0}/discussions", categoryID),
                RootElement = "discussions"
            };
            request.AddParameter("title", title);
            request.AddParameter("author_email", authorEmail);
            request.AddParameter("author_name", authorName);
            request.AddParameter("body", body);
            request.AddParameter("public", isPublic.ToString());

            IRestResponse res = Execute(request);
            return res.StatusCode == System.Net.HttpStatusCode.Created;
        }

        /// <summary>
        /// Reply to Discussion
        /// </summary>
        /// <param name="discussionID"></param>
        /// <param name="authorEmail"></param>
        /// <param name="body"></param>
        /// <param name="skipSpam"></param>
        /// <returns></returns>
        public bool ReplyToDiscussion(int discussionID, string authorEmail, string body, bool? skipSpam = true)
        {

            var request = new RestRequest
            {
                Method = Method.POST,
                RequestFormat = RestSharp.DataFormat.Json,
                Resource = string.Format("discussions/{0}/comments", discussionID),
                RootElement = "discussions"
            };

            request.AddParameter("author_email", authorEmail);
            request.AddParameter("body", body);
            request.AddParameter("skip_spam", skipSpam.ToString());

            IRestResponse res = Execute(request);
            return res.StatusCode == System.Net.HttpStatusCode.Created;
        }

        /// <summary>
        /// Does the specified action on the discussion.
        /// Actions: toggle, resolve, unresolve, acknowledge, restore
        /// </summary>
        /// <param name="discussionID"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool DoDiscussionAction(int discussionID, string action)
        {
            var request = new RestRequest
            {
                Method = Method.POST,
                RequestFormat = RestSharp.DataFormat.Json,
                Resource = string.Format("discussions/{0}/{1}", discussionID.ToString(), action),
                RootElement = "discussions"
            };

            IRestResponse res = Execute(request);
            return res.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public void QueueDiscussion(int discussionId, int queueId)
        {
            var request = new RestRequest
            {
                Method = Method.POST,
                RequestFormat = RestSharp.DataFormat.Json,
                Resource = string.Format("discussions/{0}/queue?queue={1}", discussionId, queueId),
            };

            Execute(request);
        }
    }
}
