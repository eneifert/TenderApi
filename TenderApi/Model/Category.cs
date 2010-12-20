using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenderApi.Model
{
    public class Category : TenderApiBase
    {
        public string name { get; set; }
        public string permalink { get; set; }
        public Boolean @public { get; set; }
        public string hide_support_workflow { get; set; }
        public string last_user_name { get; set; }
        public string code { get; set; }
        public string summary { get; set; }
        public string formatted_summary { get; set; }
        public string accept_email { get; set; }
        public Boolean hidden { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string last_updated_at { get; set; }
        public string heartbeat_on { get; set; }
        public string html_href { get; set; }
        public string href { get; set; }
        public string discussions_href { get; set; }

        public int GetCategoryID()
        {
            return this.GetLastIDFromHref(href);
        }
    }
}
