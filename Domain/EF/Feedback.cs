namespace Domain.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [StringLength(50)]
        [DisplayName("Tên")]
        public string Name { get; set; }

        [StringLength(50)]
        [DisplayName("Số ĐT")]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(250)]
        [DisplayName("Địa Chỉ")]
        public string Address { get; set; }

        [StringLength(250)]
        [DisplayName("Nội Dung")]
        public string Content { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Ngày Gửi")]
        public DateTime? CreatedDate { get; set; }

        [DisplayName("Tình Trạng")]
        public bool? Status { get; set; }
    }
}
