using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore.Data.Access.DataAccessModels.Dashboards
{
    [Table("AreasProperties", Schema = "productionplan")]
    public partial class AreasProperties
    {
        [Key]
        public long Id { get; set; }
        public long AreaId { get; set; }
        [Required]
        [StringLength(20)]
        public string Group { get; set; }
        [Required]
        [StringLength(20)]
        public string Parameter { get; set; }
        [Required]
        [StringLength(20)]
        public string Value { get; set; }
        public bool? Enabled { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }

        [ForeignKey("AreaId")]
        [InverseProperty("AreasProperties")]
        public virtual Areas Area { get; set; }
    }
}
