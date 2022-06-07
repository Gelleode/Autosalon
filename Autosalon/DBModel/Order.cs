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
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int StaffId { get; set; }

        public int StatusId { get; set; }

        public DateTime Date { get; set; }

        public int StoreId { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Staff Staff { get; set; }

        public virtual Status Status { get; set; }

        public virtual Store Store { get; set; }
    }
}
