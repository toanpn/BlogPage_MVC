namespace BlogPageMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbPost_Tag
    {
        public int id { get; set; }

        public int? Post_id { get; set; }

        public int? Tag_id { get; set; }

        public virtual tbPost tbPost { get; set; }

        public virtual tbTag tbTag { get; set; }
    }
}
