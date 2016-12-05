namespace Domain.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Nội Dung")]
        public string Content { get; set; }

        [DisplayName("Tình Trạng")]
        public bool? Status { get; set; }
    }
}
