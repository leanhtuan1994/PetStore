namespace Domain.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductCategory")]
    public partial class ProductCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductCategory()
        {
            Product = new HashSet<Product>();
            ProductCategory1 = new HashSet<ProductCategory>();
        }

        public long ID { get; set; }

        [StringLength(250)]
        [DisplayName("Tên DM")]
        public string Name { get; set; }

        [StringLength(250)]
        [DisplayName("Meta Title")]
        public string MetaTitle { get; set; }

        [DisplayName("Danh Mục Cha")]
        public long? ParentID { get; set; }

        [DisplayName("Thứ Tự")]
        public int? DisplayOrder { get; set; }

        [StringLength(250)]
        [DisplayName("Seo Title")]
        public string SeoTitle { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Ngày Tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        [DisplayName("Ngày Tạo")]
        public string CreatedBy { get; set; }

        [DisplayName("Ngày Sửa")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        [DisplayName("Người Tạo")]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        [DisplayName("Key Work")]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        [DisplayName("Mô Tả Ngắn")]
        public string MetaDescription { get; set; }

        [DisplayName("Trạng Thái")]
        public bool? Status { get; set; }

        public bool? ShowOnHome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCategory> ProductCategory1 { get; set; }

        public virtual ProductCategory ProductCategory2 { get; set; }
    }
}
