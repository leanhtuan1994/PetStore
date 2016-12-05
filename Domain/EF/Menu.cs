namespace Domain.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public long ID { get; set; }

        [StringLength(50)]
        [DisplayName("Tên")]
        public string Text { get; set; }

        [StringLength(250)]
        [DisplayName("Đường Dẫn")]
        public string Link { get; set; }

        [DisplayName("Thứ Tự")]
        public int? DisplayOrder { get; set; }

        [StringLength(50)]
        public string Target { get; set; }
        [DisplayName("Trạng Thái")]
        public bool? Status { get; set; }

        [DisplayName("Dạng Menu")]
        public long? TypeID { get; set; }

        public virtual MenuType MenuType { get; set; }
    }
}
