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
        /// Gets all the users
        /// </summary>
        /// <returns></returns>
        public List<FAQ> GetFAQs()
        {
            return GetCollection<FAQ>("faqs", "faqs");
        }

        /// <summary>
        /// Creates a FAQ.
        /// If no published time is given the article is left in a draft state.
        /// </summary>
        /// <param name="sectionID"></param>
        /// <param name="title"></param>
        /// <param name="keywords"></param>
        /// <param name="body"></param>
        /// <param name="published"></param>
        /// <returns></returns>
        public bool CreateFAQ(int sectionID, string title, string[] keywords, string body, DateTime? published)
        {

            var request = new RestRequest
            {
                Method = Method.POST,
                RequestFormat = RestSharp.DataFormat.Json,
                Resource = string.Format("sections/{0}/faqs", sectionID),
            };
            request.AddParameter("title", title);
            request.AddParameter("keywords", keywords);
            request.AddParameter("body", body);
            if (published != null)
                request.AddParameter("published_at", published.Value.ToString("s"));

            RestResponse res = Execute(request);
            return res.StatusCode == System.Net.HttpStatusCode.Created;
        }

        public bool UpdateFAQ(int faqID, DateTime? published, string title = "", string[] keywords = null, string body = "")
        {
            var request = new RestRequest
            {
                Method = Method.PUT,
                RequestFormat = RestSharp.DataFormat.Json,
                Resource = string.Format("faqs/{0}", faqID),
            };
            request.AddParameter("title", title);
            request.AddParameter("keywords", keywords);
            request.AddParameter("body", body);
            if (published != null)
                request.AddParameter("published_at", published.Value.ToString("s"));

            RestResponse res = Execute(request);
            return res.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
