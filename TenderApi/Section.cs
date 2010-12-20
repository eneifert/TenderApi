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
        /// Gets the Sections
        /// </summary>
        /// <returns></returns>
        public List<Section> GetSections()
        {
            return GetCollection<Section>("sections", "sections");                    
        }
    }
}
