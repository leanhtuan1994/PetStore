namespace Domain.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("About")]
    public partial class About
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [StringLength(250)]
        [DisplayName("Tên")]
        public string Name { get; set; }

        [StringLength(500)]
        [DisplayName("Mô Tả")]
        public string Description { get; set; }

        [StringLength(250)]
        [DisplayName("Tên KD")]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        [DisplayName("Hình Ảnh")]
        public string Image { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Chi Tiết")]
        public string Detail { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Ngày Tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        [DisplayName("Người Tạo")]
        public string CreatedBy { get; set; }

        [DisplayName("Ngày Sửa")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        [DisplayName("Người Sửa")]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        [DisplayName("KeyWork")]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        [DisplayName("Mô Tả Ngắn")]
        public string MetaDescription { get; set; }

        [DisplayName("Trạng Thái")]
        public bool? Status { get; set; }
    }
}
