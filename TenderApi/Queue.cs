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
        /// Get all the Queues
        /// </summary>
        /// <returns></returns>
        public List<Queue> GetQueues()
        {
            return GetCollection<Queue>("queues", "named_queues");          
        }
    }
}
