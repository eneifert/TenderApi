using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenderApi.Model
{
    public class Site : TenderApiBase
    {
        public string name { get; set; }
        public string permalink { get; set; }
        public string website { get; set; }
        public string html_href { get; set; }
        public string href { get; set; }
        public string profile_href { get; set; }
        public string users_href { get; set; }
        public string categories_href { get; set; }
        public string discussions_href { get; set; }
        public string queues_href { get; set; }
        public string sections_href { get; set; }
        public string faqs_href { get; set; }
    }
}
