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
            Orders = new HashSet<Order>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        [DisplayName("Ngày Tạo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedDate { get; set; }

        [StringLength(100)]
        [DisplayName("Người GH")]
        public string ShipName { get; set; }

        [StringLength(100)]
        [DisplayName("Địa Chỉ GH")]
        public string ShipAddress { get; set; }

        [MaxLength(50)]
        [DisplayName("Số ĐT GH")]
        public byte[] ShipPhone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
