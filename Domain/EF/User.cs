namespace Domain.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(50)]
        [DisplayName("Tên")]
        public string Name { get; set; }

        [StringLength(250)]
        [DisplayName("Địa Chỉ")]
        public string Address { get; set; }

        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(50)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Ngày Tạo")]
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
