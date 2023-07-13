namespace StoreTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TacGia")]
    public partial class TacGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TacGia()
        {
            Products = new HashSet<Product>();
        }
        [DisplayName("Ma tac gia")]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Ten tac gia")]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Hinh anh")]
        public string Image { get; set; }

        public bool? IsDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DisplayName("Sach")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
