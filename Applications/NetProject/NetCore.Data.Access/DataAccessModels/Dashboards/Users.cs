using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore.Data.Access.DataAccessModels.Dashboards
{
    [Table("Users", Schema = "productionplan")]
    public partial class Users
    {
        public Users()
        {
            Areas = new HashSet<Areas>();
            AreasProperties = new HashSet<AreasProperties>();
        }

        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string EmployeeId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public bool? Enabled { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Areas> Areas { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<AreasProperties> AreasProperties { get; set; }
    }
}
