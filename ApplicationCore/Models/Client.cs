using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }
    }
}
