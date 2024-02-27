namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class order_items
    {
        [Key]
        public int order_item_id { get; set; }

        public int? order_id { get; set; }

        public int? food_id { get; set; }

        public int? quantity { get; set; }

        public double? total { get; set; }

        public virtual food food { get; set; }

        public virtual order order { get; set; }
    }
}
