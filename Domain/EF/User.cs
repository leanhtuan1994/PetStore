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
        [DisplayName("Username")]
        public string Username { get; set; }

        [StringLength(50)]
        [DisplayName("Mật Khẩu")]
        public string Password { get; set; }


        [StringLength(50)]
        [DisplayName("Họ Tên")]
        public string Name { get; set; }

        [StringLength(250)]
        [DisplayName("Địa Chỉ")]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        [DisplayName("Số ĐT")]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Ngày Tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        [DisplayName("Người Tạo")]
        public string CreatedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Ngày Sửa")]
        public DateTime? ModifiedDate { get; set; }

        [DisplayName("Người Sửa")]
        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [DisplayName("Trạng Thái")]
        public bool? Status { get; set; }
    }
}
