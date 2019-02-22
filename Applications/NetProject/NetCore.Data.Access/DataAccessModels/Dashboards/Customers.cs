using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore.Data.Access.DataAccessModels.Dashboards
{
    [Table("Customers", Schema = "productionplan")]
    public partial class Customers
    {
        public Customers()
        {
            Areas = new HashSet<Areas>();
            Shifts = new HashSet<Shifts>();
        }

        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public bool? Enabled { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<Areas> Areas { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Shifts> Shifts { get; set; }
    }
}
