using NetCore.Data.Access.DataTransferObjects.Dashboards;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Contracts.Entity.Dashboards
{
    public interface IStoreProceduresRepository
    {
        IEnumerable<AreasParametersDTO> TestSp();
    }
}
