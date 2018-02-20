using System;
using System.Collections.Generic;
using System.Text;

namespace LetsEat.Models
{
    pubic class MasterPageItem
    {
        //Sets title of master page item
        public string Title { get; set; }

        //Sets target to be pulled for use for master detail item
        public Type TargetType { get; set; }
    }
}
