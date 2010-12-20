using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenderApi.Model
{
    public class Section : TenderApiBase
    {
        public string title { get; set; }
        public string permalink { get; set; }
        public int faqs_count { get; set; }
        public string html_href { get; set; }
        public string href { get; set; }
        public string faqs_href { get; set; }
        public string updated_at { get; set; }
        public string created_at { get; set; }

        public int GetSectionID()
        {
            //So far the only way I see to get the user id is by parsing the href
            return this.GetLastIDFromHref(href);
        }
    }
}
