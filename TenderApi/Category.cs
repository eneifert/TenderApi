﻿using System;
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
        /// Gets all the users
        /// </summary>
        /// <returns></returns>
        public List<Category> GetCategories()
        {
            return GetCollection<Category>("categories", "categories");
        }
    }
}
