namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order()
        {
            order_items = new HashSet<order_items>();
        }

        [Key]
        public int order_id { get; set; }

        public int? customer_id { get; set; }

        public int? table_id { get; set; }

        public int? employe_id { get; set; }

        public double? total { get; set; }

        public double? discount { get; set; }

        public double? net_total { get; set; }

        public DateTime? date_buy { get; set; }

        [StringLength(100)]
        public string status { get; set; }

        [StringLength(100)]
        public string progress { get; set; }

        public virtual customer customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_items> order_items { get; set; }

        public virtual user_account user_account { get; set; }

        public virtual table_order table_order { get; set; }
    }
}
