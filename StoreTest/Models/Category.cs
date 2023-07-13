namespace StoreTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Products = new HashSet<Product>();
        }
        [DisplayName("Ma Loai")]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Ten loai")]
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
