namespace StoreTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [Key]
        [StringLength(50)]
        [DisplayName("Account")]
        public string Username { get; set; }

        [StringLength(20)]
        [DisplayName("Password")]
        public string Password { get; set; }
       
    }
}
