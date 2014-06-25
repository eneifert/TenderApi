using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenderApi.Model
{
    public class User : TenderApiBase
    {
        public string name { get; set; }
        public string email { get; set; }
        public string title { get; set; }
        public string external_id { get; set; }
        public string state { get; set; }
        public bool enable_email_notifications { get; set; }
        public bool public_facing { get; set; }
        public string openid_Url { get; set; }
        public bool trusted { get; set; }
        public string href { get; set; }
        public string discussions_href { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string activated_at { get; set; }
        public string avatar_url { get; set; }
        public int? company_id { get; set; }

        public int GetUserID()
        {
            //So far the only way I see to get the user id is by parsing the href
            return this.GetLastIDFromHref(href);
        }
    }
}
