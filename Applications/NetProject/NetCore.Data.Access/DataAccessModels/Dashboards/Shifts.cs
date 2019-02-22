using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore.Data.Access.DataAccessModels.Dashboards
{
    [Table("Shifts", Schema = "productionplan")]
    public partial class Shifts
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool? Enabled { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("Shifts")]
        public virtual Customers Customer { get; set; }
    }
}
