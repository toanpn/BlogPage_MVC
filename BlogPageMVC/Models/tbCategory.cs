namespace BlogPageMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbCategory")]
    public partial class tbCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbCategory()
        {
            tbPost_Category = new HashSet<tbPost_Category>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public int? Views { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbPost_Category> tbPost_Category { get; set; }
    }
}
