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
            OrderDetails = new HashSet<OrderDetail>();
        }

        public long ID { get; set; }

        [DisplayName("Tên")]
        [StringLength(250)]
        public string Name { get; set; }

        
        [StringLength(20)]
        public string Code { get; set; }

        [DisplayName("Mô Tả")]
        [StringLength(500)]
        public string Description { get; set; }

        [DisplayName("Mô Tả Ngắn")]
        [StringLength(250)]
        public string MetaTitle { get; set; }

        [DisplayName("Hình Ảnh")]
        [StringLength(250)]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        [DisplayName("DS Hình")]
        public string MoreImages { get; set; }

        [DisplayName("Giá")]
        public decimal? Price { get; set; }
        
        [DisplayName("Giảm Giá")]
        public decimal? PromotionPrice { get; set; }

        [DisplayName("Số Lượng")]
        public int Quantity { get; set; }

        [DisplayName("Danh Mục")]
        public long? CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Chi Tiết")]
        public string Detail { get; set; }

        [DisplayName("Ngày Tạo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Ngày Sửa")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [DisplayName("KeyWord")]
        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [DisplayName("Mô Tả Ngắn")]
        [StringLength(250)]
        public string MetaDescription { get; set; }

        [DisplayName("Trạng Thái")]
        public bool? Status { get; set; }

        [DisplayName("Lượt Xem")]
        public int? ViewCount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        
        [DisplayName("Loại")]
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
