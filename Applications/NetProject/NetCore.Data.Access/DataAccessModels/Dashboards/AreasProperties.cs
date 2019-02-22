using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore.Data.Access.DataAccessModels.Dashboards
{
    [Table("AreasProperties", Schema = "productionplan")]
    public partial class AreasProperties
    {
        public long Id { get; set; }
        public long AreaId { get; set; }
        public long UserId { get; set; }
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
        [ForeignKey("UserId")]
        [InverseProperty("AreasProperties")]
        public virtual Users User { get; set; }
    }
}
