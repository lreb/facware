using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore.Data.Access.Models
{
    [Table("SystemConfiguration")]
    public class SystemConfiguration
    {
        public SystemConfiguration()
        {
        }

        [Key]
        public long Id { get; set; }
        public string Group { get; set; }
        public string Parameter { get; set; }
        public string Value { get; set; }
    }
}
