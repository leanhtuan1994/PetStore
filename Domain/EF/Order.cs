namespace Domain.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public long ID { get; set; }

        [DisplayName("Mã KH")]
        public long? CustomerID { get; set; }

        [DisplayName("Thứ Tự")]
        public int? DisplayOrder { get; set; }

        [DisplayName("Tổng Tiền")]
        public decimal? Total { get; set; }

        [DisplayName("Tình Trạng Thanh Toán")]
        public bool? OrderStatus { get; set; }
                           
        [DisplayName("Ngày Đặt Hàng")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDate { get; set; }

        [DisplayName("Ngày Giao Hàng")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ShipDate { get; set; }

        [DisplayName("Tình Trạng GH")]
        public bool? ShipStatus { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
