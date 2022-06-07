namespace Autosalon.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Car")]
    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            Order = new HashSet<Order>();
            Stock = new HashSet<Stock>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        public decimal Price { get; set; }

        public int ManufactoryId { get; set; }

        public int CategoryId { get; set; }

        public int Year { get; set; }

        public int HorsePower { get; set; }

        [StringLength(200)]
        public string PhotoPath { get; set; }

        public virtual Category Category { get; set; }

        public string Fullname => $"{Manufactory.Title} {Model}";

        public virtual Manufactory Manufactory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
