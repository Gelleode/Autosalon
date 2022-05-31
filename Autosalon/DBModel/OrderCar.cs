namespace Autosalon.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderCar")]
    public partial class OrderCar
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int CarId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public virtual Car Car { get; set; }

        public virtual Order Order { get; set; }
    }
}
