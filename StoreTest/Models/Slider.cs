namespace StoreTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slider")]
    public partial class Slider
    {
        [DisplayName("Ma")]
        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Hinh anh")]
        public string Image { get; set; }
        [DisplayName("Hien thi")]
        public bool? IsShow { get; set; }
    }
}
