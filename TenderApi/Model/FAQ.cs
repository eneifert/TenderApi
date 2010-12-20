using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenderApi.Model
{
    public class FAQ : TenderApiBase
    {
        public string title { get; set; }
        public string permalink { get; set; }
        public string keywords { get; set; }
        public string body { get; set; }
        public string formatted_body { get; set; }
        public string html_href { get; set; }
        public string href { get; set; }
        public string section_href { get; set; }
        public string published_at { get; set; }
        public string updated_at { get; set; }
        public string created_at { get; set; }

        public int GetFAQID()
        {
            //So far the only way I see to get the user id is by parsing the href
            return this.GetLastIDFromHref(href);
        }
    }
}
