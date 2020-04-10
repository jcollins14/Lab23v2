using System;
using System.Collections.Generic;

namespace Lab23v2.Models
{
    public partial class Items
    {
        public int ItemId { get; set; }
        public string ItemDesc { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
    }
}
