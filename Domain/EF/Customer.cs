namespace Domain.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Orders = new HashSet<Orders>();
        }

        public long ID { get; set; }

        [StringLength(100)]
        [DisplayName("Tên")]
        public string Name { get; set; }

        [StringLength(100)]
        [DisplayName("Địa Chỉ")]
        public string Address { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        [DisplayName("Số ĐT")]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Ngày Tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(100)]
        [DisplayName("Tên Người Nhận")]
        public string ShipName { get; set; }

        [StringLength(100)]
        [DisplayName("Địa Chỉ NN")]
        public string ShipAddress { get; set; }


        [DisplayName("Số ĐT NN")]
        [StringLength(50)]
        public string ShipPhone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
