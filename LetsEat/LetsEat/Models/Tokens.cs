using System;
using System.Collections.Generic;
using System.Text;

namespace LetsEat.Models
{
    public class Tokens
    {
        // Variable descriptions
        // -id: used by the database for information storage identification
        // -accessToken: Will contain the access token received from the server
        // -errDescription: Will hold any error messages received from server
        // -expiration: Contains token expiration 
        public int id { get; set; }
        public string accessToken { get; set; }
        public string errDescription { get; set; }
        public DateTime expiration { get; set; }

        // Empty constructor for Token class
        public Tokens() { }
    }
}
