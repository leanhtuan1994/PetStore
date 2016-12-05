namespace Domain.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Đơn Hàng")]
        public long OrderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Sản Phẩm")]
        public long ProductID { get; set; }

        [DisplayName("Thứ Tự")]
        public int? DisplayOrder { get; set; }

        [DisplayName("Đơn Giá")]
        public decimal? Price { get; set; }

        [DisplayName("Số Lượng")]
        public int? Quantity { get; set; }

        [DisplayName("Tổng Giá")]
        public decimal? Total { get; set; }

        public virtual Orders Orders { get; set; }

        public virtual Product Product { get; set; }
    }
}
