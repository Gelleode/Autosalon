using System.Linq;

namespace Autosalon.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderCar = new HashSet<OrderCar>();
        }

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int StaffId { get; set; }

        public int StatusId { get; set; }

        public DateTime Date { get; set; }

        public int StoreId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Staff Staff { get; set; }

        public virtual Status Status { get; set; }

        public virtual Store Store { get; set; }

        public decimal Price
        {
            get
            {
                decimal sum = 0;
                foreach (var car in OrderCar) sum += car.Price;
                return sum;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderCar> OrderCar { get; set; }
    }
}
