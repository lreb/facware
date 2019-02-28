using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Data.Access.DataTransferObjects.Dashboards
{
    public class AreasParametersDTO
    {
        public long? CustomerId { get; set; }
        public string Name { get; set; }
        public bool? Enabled { get; set; }
        public string Group { get; set; }
        public string Parameter { get; set; }
        public string Value { get; set; }
    }
}
