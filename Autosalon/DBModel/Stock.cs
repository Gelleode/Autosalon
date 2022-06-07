namespace Autosalon.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stock")]
    public partial class Stock
    {
        [Key]
        public int Id { get; set; }

        public int StoreId { get; set; }
        public int CarId { get; set; }

        public int Quantity { get; set; }

        public virtual Car Car { get; set; }

        public virtual Store Store { get; set; }
    }
}
