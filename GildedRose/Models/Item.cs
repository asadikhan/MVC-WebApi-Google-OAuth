using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GildedRose.Models
{
    public class Item
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public int price { get; set; }

        public bool available { get; set; }

        public string soldToName { get; set; }
    }
}