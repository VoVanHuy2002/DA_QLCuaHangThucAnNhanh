namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user_account()
        {
            orders = new HashSet<order>();
        }

        [Key]
        public int user_id { get; set; }

        [Required]
        [StringLength(255)]
        public string username { get; set; }

        [Required]
        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string full_name { get; set; }

        [StringLength(50)]
        public string gender { get; set; }

        public int? age { get; set; }

        [StringLength(500)]
        public string address { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        public int? role_id { get; set; }

        [StringLength(100)]
        public string status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }

        public virtual role role { get; set; }
    }
}
