namespace BlogPageMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbTag")]
    public partial class tbTag
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbTag()
        {
            tbPost_Tag = new HashSet<tbPost_Tag>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Views { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbPost_Tag> tbPost_Tag { get; set; }
    }
}
