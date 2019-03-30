namespace BlogPageMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbPost")]
    public partial class tbPost
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbPost()
        {
            tbComments = new HashSet<tbComment>();
            tbPost_Category = new HashSet<tbPost_Category>();
            tbPost_Tag = new HashSet<tbPost_Tag>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string Tittle { get; set; }

        [StringLength(255)]
        public string Url { get; set; }

        public string ShortContent { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public int? Views { get; set; }

        public int? Shares { get; set; }

        public DateTime? DateCreate { get; set; }

        public DateTime? DatePublish { get; set; }

        public bool? Visiable { get; set; }

        public int? Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbComment> tbComments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbPost_Category> tbPost_Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbPost_Tag> tbPost_Tag { get; set; }
    }
}
