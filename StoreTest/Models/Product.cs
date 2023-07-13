namespace StoreTest.Models
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
            ImageProducts = new HashSet<ImageProduct>();
        }
        [DisplayName("Ma sach")]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Ten sach")]
        public string Name { get; set; }
        [DisplayName("Gia ban")]
        public int Cost { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Gioi thieu")]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Thong so")]
        public string Details { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Hinh anh")]
        public string Image { get; set; }
        [DisplayName("Dang giam gia")]
        public bool? IsSeller { get; set; }
        [DisplayName("On top")]
        public bool? OnTop { get; set; }
        [DisplayName("Loai")]
        public int IDCategory { get; set; }
        [DisplayName("Tac gia")]
        public int IDTacGia { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImageProduct> ImageProducts { get; set; }

        public virtual TacGia TacGia { get; set; }
    }
}
