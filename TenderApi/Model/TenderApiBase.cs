using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace TenderApi.Model
{

    /// <summary>
    /// Base class for all Twilio resource types
    /// </summary>
    public abstract class TenderApiBase
    {        
        /// <summary>
        /// The URI for this resource, relative to https://api.tenderapp.com/
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// Parses the href and returns the last param that can be converted in an int.
        /// This is kind of a strange way of finding an ID but as of now, this is the only way the ID is exposed.
        /// </summary>
        /// <param name="href"></param>
        /// <returns></returns>
        public int GetLastIDFromHref(string href)
        {

            //So far the only way I see to get the user id is by parsing the href
            string[] parsedUrl = href.Split('/');
            int result = 0;
            foreach(string s in parsedUrl.Reverse<string>())
            {
                if (int.TryParse(s, out result))
                    break;
            }
            
            return result;
        }
    }


}
