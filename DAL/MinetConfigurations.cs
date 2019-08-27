using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace FIRERISK.DAL
{
    public class MinetConfigurations : DbConfiguration
    {
        public MinetConfigurations()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}


//Code Resiliency