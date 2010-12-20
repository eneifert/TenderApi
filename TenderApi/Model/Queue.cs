using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenderApi.Model
{
    public class Queue : TenderApiBase
    {
        public string name { get; set; }
        public string permalink { get; set; }
        public string show_order { get; set; }
        public List<string> show_states { get; set; }
        public List<int> notification_ids { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string html_href { get; set; }
        public string href { get; set; }
        public string discussions_href { get; set; }
    }
}
