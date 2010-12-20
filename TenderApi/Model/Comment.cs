using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenderApi.Model
{
    public class Comment : TenderApiBase
    {
        public string author_name { get; set; }
        public string author_email { get; set; }
        public string body { get; set; }
        public bool resolution { get; set; }
        public int number { get; set; }
        public string via { get; set; }
        public bool user_is_supporter { get; set; }
        public string user_ip { get; set; }
        public string user_agent { get; set; }
        public string referrer { get; set; }
        public bool skip_spam { get; set; }
        public int user_id { get; set; }
        public string formatted_body { get; set; }
        public string html_href { get; set; }
        public string user_href { get; set; }
        public string created_at { get; set; }

    }
}
