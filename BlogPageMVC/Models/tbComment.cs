namespace BlogPageMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbComment")]
    public partial class tbComment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbComment()
        {
            tbComment1 = new HashSet<tbComment>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string NameOwner { get; set; }

        public DateTime? Time { get; set; }

        public bool? Visiable { get; set; }

        public string Content { get; set; }

        public int? Post_id { get; set; }

        public int? Parent_id { get; set; }

        public int? Likes { get; set; }

        public bool? isMasterComment { get; set; }

        public bool? isDeleted { get; set; }

        public bool? isEdited { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbComment> tbComment1 { get; set; }

        public virtual tbComment tbComment2 { get; set; }

        public virtual tbPost tbPost { get; set; }
    }
}
