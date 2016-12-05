namespace Domain.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public long ID { get; set; }

        [StringLength(250)]
        [DisplayName("Tên SP")]
        public string Name { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(500)]
        [DisplayName("Mô Tả")]
        public string Description { get; set; }

        [StringLength(250)]
        [DisplayName("Meta Title")]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        [DisplayName("Hình Ảnh")]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        [DisplayName("Nhiều Ảnh")]
        public string MoreImages { get; set; }

        [DisplayName("Giá")]
        public decimal? Price { get; set; }

        [DisplayName("Giá Giảm")]
        public decimal? PromotionPrice { get; set; }

        [DisplayName("Số Lượng")]
        public int Quantity { get; set; }

        [DisplayName("Danh Mục")]
        public long? CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Chi Tiết")]
        public string Detail { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Ngày Tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        [DisplayName("Ngày Tạo")]
        public string CreatedBy { get; set; }

        [DisplayName("Ngày Sửa")]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        [DisplayName("Người Sửa")]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        [DisplayName("Key Work")]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        [DisplayName("Mô Tả Ngắn")]
        public string MetaDescription { get; set; }

        [DisplayName("Trạng Thái")]
        public bool? Status { get; set; }

        [DisplayName("Số Lượng")]
        public int? ViewCount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
