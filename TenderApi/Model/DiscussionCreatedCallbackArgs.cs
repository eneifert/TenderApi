using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TenderApi.Model
{
    public class DiscussionCreatedCallbackArgs
    {
        [JsonProperty(PropertyName = "user_is_supporter")]
        public bool UserIsSupporter { get; set; }

        [JsonProperty(PropertyName = "author_name")]
        public string AuthorName { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "formatted_body")]
        public string FormattedBody { get; set; }

        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "user")]
        public User User { get; set; }

        [JsonProperty(PropertyName = "internal")]
        public bool Internal { get; set; }

        [JsonProperty(PropertyName = "system_message")]
        public bool SystemMessage { get; set; }

        [JsonProperty(PropertyName = "user_ip")]
        public string UserIp { get; set; }

        [JsonProperty(PropertyName = "discussion")]
        public Discussion Discussion { get; set; }

        [JsonProperty(PropertyName = "referrer")]
        public string Referrer { get; set; }

        [JsonProperty(PropertyName = "via")]
        public string Via { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        [JsonProperty(PropertyName = "author_email")]
        public string AuthorEmail { get; set; }

        [JsonProperty(PropertyName = "category")]
        public Category Category { get; set; }
    }
}
