namespace Domain.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        public long ID { get; set; }

        [StringLength(250)]
        [DisplayName("Hình Ảnh")]
        public string Image { get; set; }

        [DisplayName("Thứ Tự")]
        public int? DisplayOrder { get; set; }

        [StringLength(250)]
        public string Link { get; set; }

        [StringLength(250)]
        [DisplayName("Mô Tả")]
        public string Description { get; set; }

        [DisplayName("Ngày Tạo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        [DisplayName("Người Tạo")]
        public string CreatedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Ngày Sửa")]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        [DisplayName("Người Sửa")]
        public string ModifiedBy { get; set; }

        [DisplayName("Trạng Thái")]
        public bool? Status { get; set; }
    }
}
