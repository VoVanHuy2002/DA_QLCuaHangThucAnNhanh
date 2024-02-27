namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("food")]
    public partial class food
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public food()
        {
            order_items = new HashSet<order_items>();
        }

        [Key]
        public int food_id { get; set; }

        [Required]
        [StringLength(255)]
        public string food_name { get; set; }

        public string food_image { get; set; }

        public string food_image_adr { get; set; }

        public double? price { get; set; }

        public string description { get; set; }

        [StringLength(100)]
        public string status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_items> order_items { get; set; }
    }
}
