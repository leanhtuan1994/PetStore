namespace Domain.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tag")]
    public partial class Tag
    {
        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(50)]
        [DisplayName("T�n")]
        public string Name { get; set; }
    }
}
