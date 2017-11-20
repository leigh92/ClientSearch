using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientSearch.Models
{
    public class ApiClient
    {

        public string clientId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email  { get; set; }
        public string mobile { get; set; }
    }
}