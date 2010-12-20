using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenderApi.Model
{
    public class Discussion : TenderApiBase
    {
        public string title { get; set; }
        public string permalink { get; set; }
        public Int32 number { get; set; }
        public string author_email { get; set; }
        public string author_name { get; set; }
        public Boolean @public { get; set; }
        public string via { get; set; }
        public Boolean unread { get; set; }
        public string  category_id { get; set; }
        public string redirection_id { get; set; }
        public string private_body { get; set; }
        public Int32 comments_count { get; set; }
        public long avg_response_time { get; set; }
        public string state { get; set; }
        public int watched_discussion_count { get; set; }
        public Boolean hidden { get; set; }
        public Int32 user_id { get; set; }
        public Int32 last_user_id { get; set; }
        public Int32 last_comment_id { get; set; }
        public string last_via { get; set; }
        public string last_author_email { get; set; }
        public string last_author_name { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string last_updated_at { get; set; }
        public string html_href { get; set; }
        public string href { get; set; }
        public string comments_href { get; set; }
        public string queue_href { get; set; }
        public string unqueue_href { get; set; }
        public string toggle_href { get; set; }
        public string resolve_href { get; set; }
        public string unresolve_href { get; set; }
        public string change_category_href { get; set; }
        public string restore_href { get; set; }
        public string acknowledge_href { get; set; }

        public int GetDiscussionID()
        {
            //So far the only way I see to get the user id is by parsing the href
            return this.GetLastIDFromHref(href);
        }
    }   
}
