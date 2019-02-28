using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore.Data.Access.DataAccessModels.Dashboards
{
    [Table("Areas", Schema = "productionplan")]
    public partial class Areas
    {
        public Areas()
        {
            AreasProperties = new HashSet<AreasProperties>();
        }
        [Key]
        public long Id { get; set; }
        public long CustomerId { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(20)]
        public string Type { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public bool? Enabled { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("Areas")]
        public virtual Customers Customer { get; set; }
        [InverseProperty("Area")]
        public virtual ICollection<AreasProperties> AreasProperties { get; set; }
    }
}
